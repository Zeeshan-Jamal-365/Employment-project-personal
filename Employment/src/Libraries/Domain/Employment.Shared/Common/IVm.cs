using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Shared.Common;
public interface IVm<T> where T : IEquatable<T>
{
    T Id { get; set; }

}

public interface IVm : IVm<int>
{

}

