using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Domain.Lazy
{
    public interface IValueHolder<T> {
        T GetValue(object param);
    }
    public class ValueHolder<T>:IValueHolder<T>
    {
        private T _value;
        private Func<object, T> _getFor;
        public ValueHolder(Func<object,T> getFor) {
            _getFor = getFor;
        }
        public T GetValue(object param) {
            return _getFor(param);
        }
    }
}
