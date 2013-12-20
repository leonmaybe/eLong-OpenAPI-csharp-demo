using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace OpenAPITest.GModel
{
    public class GCreateOrderCondition
    {

        public string CreatorIP { get; set; }
        public string AmendorIP { get; set; }

        public string ContactPersonName { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string MobileTelephone { get; set; }
        public Sex Sex { get; set; }
        public string Telephone { get; set; }
        public DateTime ArriveHotelTime { get; set; }
        public decimal AverageBaseRate { get; set; }
        public decimal AverageRate { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }


        public string CurrencyCode { get; set; }
        public string HotelAddress { get; set; }
        public string HotelID { get; set; }
        public string HotelName { get; set; }
        public string HotelTel { get; set; }
        public InterHotelRoomType[] InterHotelRoomTypes { get; set; }
        public decimal MaxNightlyRate { get; set; }
        public decimal NightlyRateTotal { get; set; }
        public string Remark { get; set; }
        public int RoomNum { get; set; }


        public decimal SurchargeTotal { get; set; }
        public decimal Total { get; set; }
        public decimal extraPersonFees { get; set; }
        public string hotelCountry { get; set; }
        public string hotelcity { get; set; }
        public string TravelerName { get; set; }
        public decimal InvoiceFee { get; set; }

        public string InvoiceTitle { get; set; }
        public string CertificateNO { get; set; }
        public IdentityCardType CertificateType { get; set; }
        public string CreditCardNO { get; set; }
        public int CreditVerifyCode { get; set; }

        public DateTime ExpiredTime { get; set; }
        public string HolderName { get; set; }
        public bool IsInternationalCard { get; set; }
        public string ExtendInfo { get; set; }
        public string AgencyOrderID { get; set; }
        public int IsGurantedOrCharged { get; set; }



    }

    


}
