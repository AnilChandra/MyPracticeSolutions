using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkintLot
{

    class ParkingLot : IParkingLot
    {

        List<ParkingFloor> parkingFloors;
        List<Entrance> entrances;
        List<Exit> exits;

        Address address;

        String parkingLotName;

        public Boolean isParkingSpaceAvailableForVehicle(Vehicle vehicle) { return true; }
        public Boolean updateParkingAttndant(ParkingAttendant parkingAttendant, int gateId) { return true; }

    }

    class ParkingFloor
	{

		int levelId;
		List<ParkingSpace> parkingSpaces;
		ParkingDisplayBoard parkingDisplayBoard;

	}

	class Gate
	{

		int gateId;
		ParkingAttendant parkingAttendant;

	}

	class Entrance : Gate
	{

		public ParkingTicket getParkingTicket(Vehicle vehicle) { ParkingTicket pt = new ParkingTicket(); return pt; }

}

    class Exit : Gate
{

		public ParkingTicket payForParking(ParkingTicket parkingTicket, PaymentType paymentType) { ParkingTicket pt = new ParkingTicket(); return pt; }

}

   class Address
{

	String country;
	String state;
	String city;
	String street;
	String pinCode; //ZipCode
}

   class ParkingSpace
{

	int spaceId;
	Boolean isFree;
	double costPerHour;
	Vehicle vehicle;
	ParkingSpaceType parkingSpaceType;

}

   class ParkingDisplayBoard
{

	Dictionary<ParkingSpaceType, int> freeSpotsAvailableMap;

	public void updateFreeSpotsAvailable(ParkingSpaceType parkingSpaceType, int spaces) { }

}

  class Account
{

	String name;
	String email;
	String password;
	String empId;
	Address address;

}

  class Admin : Account
{

		public Boolean addParkingFloor(ParkingLot parkingLot, ParkingFloor floor) { return true; }
		public Boolean addParkingSpace(ParkingFloor floor, ParkingSpace parkingSpace) { return true; }
		public Boolean addParkingDisplayBoard(ParkingFloor floor, ParkingDisplayBoard parkingDisplayBoard) { return true; }
	

}

  class ParkingAttendant : Account
{

	Payment paymentService;

		public Boolean processVehicleEntry(Vehicle vehicle) { return true; }
		public PaymentInfo processPayment(ParkingTicket parkingTicket, PaymentType paymentType) { PaymentInfo pi = new PaymentInfo(); return pi; }

}

  class Vehicle
{

	String licenseNumber;
	VehicleType vehicleType;
	ParkingTicket parkingTicket;
	PaymentInfo paymentInfo;

}

  class ParkingTicket
{

	int ticketId;
	int levelId;
	int spaceId;
	DateTime vehicleEntryDateTime;
	DateTime vehicleExitDateTime;
	ParkingSpaceType parkingSpaceType;
	double totalCost;
	ParkingTicketStatus parkingTicketStatus;

		public void updateTotalCost() { }
		public void updateVehicleExitTime(DateTime vehicleExitDateTime) { }

}

  public enum PaymentType
{

	CASH, CEDIT_CARD, DEBIT_CARD, UPI
}

  public enum ParkingSpaceType
{

	BIKE_PARKING, CAR_PARKING, TRUCK_PARKING

}

  class Payment
{

		public PaymentInfo makePayment(ParkingTicket parkingTicket, PaymentType paymentType) { PaymentInfo pi = new PaymentInfo(); return pi; }
}

  public class PaymentInfo
  {

	double amount;
	DateTime paymentDate;
	int transactionId;
	ParkingTicket parkingTicket;
	PaymentStatus paymentStatus;

  }

  public enum VehicleType
  {

	BIKE, CAR, TRUCK
  }

  public enum ParkingTicketStatus
  {

	PAID, ACTIVE
  }

  public enum PaymentStatus
  {

	UNPAID, PENDING, COMPLETED, DECLINED, CANCELLED, REFUNDED

  }

}
