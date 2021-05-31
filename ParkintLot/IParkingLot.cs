namespace ParkintLot
{
    interface IParkingLot
    {
        bool isParkingSpaceAvailableForVehicle(Vehicle vehicle);
        bool updateParkingAttndant(ParkingAttendant parkingAttendant, int gateId);
    }
}