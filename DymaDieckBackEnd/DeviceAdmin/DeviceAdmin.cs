using Dapper.Contrib.Extensions;
using Newtonsoft.Json;
using System;

namespace DymaDieckBackend.DeviceAdmin
{
    #region Device
    [Table("Device")]
    public class Device
    {
        [Key]
        public int NPK_Device { get; set; }
        public int NFK_Client { get; set; }
        public string IMEI { get; set; }
        public string PhoneNumber { get; set; }
        public int NFK_Carrier { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int Active { get; set; }
    }
    #endregion

    #region Carrier
    [Table("Carrier")]
    public class Carriers
    {
        [Key]
        public int NPK_Carrier { get; set; }
        public string Carrier { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int Active { get; set; }
    }
    #endregion

    #region Client
    [Table("Client")]
    public class Clients
    {
        [Key]
        public int NPK_Client { get; set; }
        public string Client { get; set; }
        public string ShortName { get; set; }
        public int Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string HostServerDB { get; set; }
        public string DBName { get; set; }
        public string DBUser { get; set; }
        public string DBPassword { get; set; }

    }
    #endregion

    #region User
    [Table("User")]
    public class User
    {
        [Key]
        public int NPK_User { get; set; }
        public int NFK_Client { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? NFK_Device { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int Active { get; set; }

    }
    #endregion

    #region vwDeviceAuthorized
    [Table("vw_DeviceAuthorized")]
    public class vw_DeviceAuthorized
    {
        public int NPK_Device { get; set; }
        public int NFK_Client { get; set; }
        public int NFK_Carrier { get; set; }
        public string IMEI { get; set; }
        public string PhoneNumber { get; set; }
        public string Client { get; set; }
        public string Carrier { get; set; }

    }
    #endregion

    #region vwUserAuthorized
    [Table("vw_UserAuthorized")]
    public class vw_UserAuthorized
    {
        public int NPK_User { get; set; }
        public int NFK_Client { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Client { get; set; }
        public string HostServerDB { get; set; }
        public string DBName { get; set; }
        public string DBUser { get; set; }
        public string DBPassword { get; set; }
        public bool IsSupervisor { get; set; }
        public int NFK_Employee { get; set; }
    }
    #endregion
}
