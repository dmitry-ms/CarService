using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace CarService.Web.Extentions
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }

        public static int GetBasketCount(this ISession session, Guid carId)
        {
            var basket = session.Get<IList<Guid>>(carId.ToString());
            if (basket != null)
            {
                return basket.Count();
            }
            return 0;
        }

        public static IEnumerable<Guid> GetBasketItems(this ISession session, Guid carId)
        {
            var basket = session.Get<IList<Guid>>(carId.ToString());
            if (basket != null)
            {
                return basket;
            }
            return new List<Guid>();
        }

        public static int AddToBasket(this ISession session, Guid serviceId, Guid carId)
        {
            var basket = session.Get<IList<Guid>>(carId.ToString());
            if (basket == null)
            {
                basket = new List<Guid>();
                basket.Add(serviceId);
                session.Set(carId.ToString(), basket);
                return 1;
            }
            else
            {
                basket.Add(serviceId);
                session.Set(carId.ToString(), basket);
                return basket.Count();
            }
        }

        public static int RemoveFromBasket(this ISession session, Guid serviceId, Guid carId)
        {
            var basket = session.Get<IList<Guid>>(carId.ToString());
            if (basket != null)
            {
                basket.Remove(serviceId);
                session.Set(carId.ToString(), basket);
                return basket.Count();
            }
            return 0;
        }

        public static void CleanBasket(this ISession session, Guid carId)
        {
            session.Set(carId.ToString(), new List<Guid>());
        }
    }
}
