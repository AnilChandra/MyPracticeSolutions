using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace DesignLowLevel
{
    public class ParkingLot : IParkingLot
    {
        public string Address { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void AddFloor()
        {
            throw new NotImplementedException();
        }

        public void AvailableSpot()
        {
            throw new NotImplementedException();
        }

        public void IsFull()
        {
            throw new NotImplementedException();
        }

        List<ParkingFloor> parkingFloors;
    }

    public class ParkingFloor
    { 
        string Name { get; set; }
        public void AddSpot() { }
        List<ParkingSpot> parkingSpots;
    }
    public class ParkingSpot
    {
        int Number { get; set; }
        public void IsFull() { }
    }

    public class Test : ParkingSpot
    { 
      
    }
}
