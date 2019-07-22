using Krooze.EntranceTest.WriteHere.Structure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Krooze.EntranceTest.WriteHere.Tests.InjectionTests
{
    public class InjectionMap<TRequest>
        where TRequest : IRequest
    {
        private Dictionary<Type, Func<TRequest, bool>> _maps;

        public InjectionMap()
        {
            this._maps = new Dictionary<Type, Func<TRequest, bool>>();
        }

        public void Map(Type Type, Func<TRequest, bool> Predicate)
        {
            this._maps.Add(Type, Predicate);
        }

        public TCompany Factory<TCompany>(TRequest Request)
        {
            var Type = this._maps.Where(t => t.Value.Invoke(Request)).FirstOrDefault().Key;
            if (Type != null)
            {
                return (TCompany)Activator.CreateInstance(Type);
            }
            else
                throw new Exception("Tipo solicitado não mapeado para conversão");
        }
    }
}
