using System;
using System.Collections.Generic;
using System.Text;

namespace DesignLowLevel
{
    interface IParkingLot
    {
        String Address { get; set; }
        //List<ParkingFloor> parkingFloors;
        void AddFloor();
        void IsFull();
        void AvailableSpot();
    }
}
