using System;

namespace Core
{
    public interface IStaff
    {
        string Name { get; }
        DateTime Date { get; }
        int GetSalary();
    }
}