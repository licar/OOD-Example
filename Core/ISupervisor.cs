using System.Collections.Generic;

namespace Core
{
    public interface ISupervisor : IStaff
    {
        IEnumerable<IStaff> Subordinates { get; }
    }
}