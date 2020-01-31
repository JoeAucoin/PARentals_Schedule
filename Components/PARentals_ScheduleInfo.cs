using System;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;

namespace GIBS.PARentals_Schedule.Components
{
    public class PARentals_ScheduleInfo
    {
        //private vars exposed thro the
        //properties
        private int moduleId;
        private int itemId;
        private string content;
        private int createdByUserID;
        private int updatedByUserID;
        private DateTime createdDate;
        private string createdByUserName = null;

        private int propertyID;
        private int propertyTypeID;
        private string propertyAddress;
        private string propertyCity;

        private int bedrooms;
        private int bathrooms;

        private DateTime dateStart;
        private DateTime dateEnd;
        private double rentalAmount;
        private string status;

        private string fullName;
        private string email;
        private string telephone;

        private int bookingID;
        private int reservationID;
        private int agentID;
        private int tenantID;

        private double depositAmt = 0;
        private DateTime depositPaidDate;
        private double balanceAmt = 0;
        private DateTime balancePaidDate;
        private string notes;


        /// <summary>
        /// empty cstor
        /// </summary>
        public PARentals_ScheduleInfo()
        {
        }


        #region properties

        public string Notes
        {
            get { return notes; }
            set { notes = value; }
        }

        public double DepositAmt
        {
            get { return depositAmt; }
            set { depositAmt = value; }
        }

        public DateTime DepositPaidDate
        {
            get { return depositPaidDate; }
            set { depositPaidDate = value; }
        }

        public DateTime BalancePaidDate
        {
            get { return balancePaidDate; }
            set { balancePaidDate = value; }
        }

        public double BalanceAmt
        {
            get { return balanceAmt; }
            set { balanceAmt = value; }
        }


        public int AgentID
        {
            get { return agentID; }
            set { agentID = value; }
        }

        public int TenantID
        {
            get { return tenantID; }
            set { tenantID = value; }
        }



        public int BookingID
        {
            get { return bookingID; }
            set { bookingID = value; }
        }

        public int ReservationID
        {
            get { return reservationID; }
            set { reservationID = value; }
        }

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }


        public DateTime DateStart
        {
            get { return dateStart; }
            set { dateStart = value; }
        }

        public DateTime DateEnd
        {
            get { return dateEnd; }
            set { dateEnd = value; }
        }

        public double RentalAmount
        {
            get { return rentalAmount; }
            set { rentalAmount = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public int PropertyID
        {
            get { return propertyID; }
            set { propertyID = value; }
        }

        public int PropertyTypeID
        {
            get { return propertyTypeID; }
            set { propertyTypeID = value; }
        }

        public string PropertyAddress
        {
            get { return propertyAddress; }
            set { propertyAddress = value; }
        }

        public string PropertyCity
        {
            get { return propertyCity; }
            set { propertyCity = value; }
        }


        public int Bedrooms
        {
            get { return bedrooms; }
            set { bedrooms = value; }
        }

        public int Bathrooms
        {
            get { return bathrooms; }
            set { bathrooms = value; }
        }

        public int ModuleId
        {
            get { return moduleId; }
            set { moduleId = value; }
        }

        public int ItemId
        {
            get { return itemId; }
            set { itemId = value; }
        }

        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        public int CreatedByUserID
        {
            get { return createdByUserID; }
            set { createdByUserID = value; }
        }

        public int UpdatedByUserID
        {
            get { return updatedByUserID; }
            set { updatedByUserID = value; }
        }

        public DateTime CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; }
        }

        public string CreatedByUserName
        {
            get
            {
                if (createdByUserName == null)
                {
                    //int portalId = PortalController.GetCurrentPortalSettings().PortalId;
                    //UserInfo user = UserController.GetUser(portalId, createdByUser, false);
                    //createdByUserName = user.DisplayName;

                    createdByUserName = "";
                }

                return createdByUserName;
            }
        }

        #endregion
    }
}
