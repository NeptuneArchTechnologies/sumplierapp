using System;
using System.Collections.Generic;
using System.Text;

namespace sumplierapp.Interface
{
    public interface ApiObjectCallback<T>
    {
        void OnSuccess(T data);
        void OnFail(string message);
    }
}
