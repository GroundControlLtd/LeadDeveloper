using System;
using Shared;

namespace Data
{
    public interface IGarageRepository
    {
        DateTime BookMot(Car car);
    }
}