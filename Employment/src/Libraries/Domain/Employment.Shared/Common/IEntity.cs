using Employment.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Shared.Common;
public interface IEntity<T> where T : IEquatable<T>
{
    T Id { get; set; }
    DateTimeOffset Created { get; set; }
    string CreatedBy { get; set; }

    DateTimeOffset? LastModified { get; set; }
    string? LastModifiedBy { get; set; }
    EntityStatus Status { get; set; }

}
public interface IEntity : IEntity<int>
{


}
