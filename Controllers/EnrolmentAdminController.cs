using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using MySqlConnector;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

using eQERPGYF_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace eQERPGYF_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrolmentAdminController : ControllerBase
    {

        private CoreDbContext _context = new CoreDbContext();
        public MySqlConnection Connection { get; }
        private readonly IConfiguration _configuration;

        #region Master method

        [HttpGet(nameof(GetAllState))]
        public async Task<ActionResult<IEnumerable<States>>> GetAllState()
        {
            try
            {
                var result = (from ste in _context.States
                              select new
                              {
                                  ste.steId,
                                  ste.steName,
                                  ste.steCode,
                                  ste.steActive,
                                  Fullname = ste.steName + " " + ste.steNameInTamil
                              }).ToList();
                int count = result.Count();
                if (count == 0)
                {
                    return Ok(new { success = false, Content = result });
                }
                return Ok(new { success = true, Content = result });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { code = StatusCodes.Status400BadRequest, type = "Failed", message = ex.ToString() });
            }
        }

        [HttpGet(nameof(GetAllDistrictById))]
        public async Task<ActionResult<IEnumerable<City>>> GetAllDistrictById(int stateId)
        {
            var result = (from cte in _context.City
                          join ste in _context.States on cte.ctyStateId equals ste.steId
                          where cte.ctyStateId == stateId
                          select new
                          {
                              cte.ctyId,
                              cte.ctyName,
                              cte.ctyCode,
                              cte.ctyActive,
                              ste.steName,
                              Fullname = cte.ctyName + " " + cte.ctyNameInTamil
                          }).ToList();

            int count = result.Count();
            if (count == 0)
            {
                return Ok(new { success = false, Content = result });
            }
            return Ok(new { success = true, Content = result });
        }

        [HttpGet(nameof(GetAllTalukByDistrict))]
        public async Task<ActionResult<IEnumerable<Taluk>>> GetAllTalukByDistrict(int cityId)
        {
            var result = (from tlk in _context.Taluk
                          join cte in _context.City on tlk.tlkCityId equals cte.ctyId
                          where tlk.tlkCityId == cityId
                          select new
                          {
                              tlk.tlkId,
                              tlk.tlkName,
                              tlk.tlkCode,
                              tlk.tlkActive,
                              Fullname = tlk.tlkName + " " + tlk.tlkNameInTamil
                          }).ToList();
            int count = result.Count();
            if (count == 0)
            {
                return Ok(new { success = false, Content = result });
            }
            return Ok(new { success = true, Content = result });
        }

        [HttpGet(nameof(GetAllBlocksByTalukId))]
        public async Task<ActionResult<IEnumerable<Blocks>>> GetAllBlocksByTalukId(int TalukId)
        {
            var result = (from blk in _context.Blocks
                          join tlk in _context.Taluk on blk.blkTalukId equals tlk.tlkId
                          where TalukId == blk.blkTalukId
                          select new
                          {
                              blk.blkId,
                              blk.blkName,
                              blk.blkCode,
                              blk.blkActive,
                              tlk.tlkName,
                              Fullname = blk.blkName + " " + blk.blkNameInTamil

                          }).ToList();

            int count = result.Count();
            if (count == 0)
            {
                return Ok(new { success = false, Content = result });
            }
            return Ok(new { success = true, Content = result });
        }

        [HttpGet(nameof(GetAllVillageByBlocksId))]
        public async Task<ActionResult<IEnumerable<Village>>> GetAllVillageByBlocksId(int BlocksId)
        {
            var result = (from vlg in _context.village
                          join blk in _context.Blocks on vlg.vlgBlockId equals blk.blkId
                          where BlocksId == vlg.vlgBlockId
                          select new
                          {
                              vlg.vlgId,
                              vlg.vlgName,
                              vlg.vlgCode,
                              vlg.vlgActive,
                              blk.blkName,
                          }).ToList();
            int count = result.Count();
            if (count == 0)
            {
                return Ok(new { success = false, Content = result });
            }
            return Ok(new { success = true, Content = result });
        }

        [HttpGet(nameof(GetAllPinCodeById))]
        public async Task<ActionResult<IEnumerable<PinCode>>> GetAllPinCodeById(int districtId)
        {
            var result = (from pin in _context.PinCode
                          join cte in _context.City on pin.pinCityId equals cte.ctyId
                          where pin.pinCityId == districtId
                          select new
                          {
                              pin.pinId,
                              pin.pinName,
                              pin.pinCode,
                              pin.pinActive,
                              cte.ctyName,
                          }).ToList();
            int count = result.Count();
            if (count == 0)
            {
                return Ok(new { success = false, Content = result });
            }
            return Ok(new { success = true, Content = result });
        }

        [HttpGet(nameof(GetAllFarmingType))]
        public async Task<ActionResult<IEnumerable<FarmingType>>> GetAllFarmingType()
        {
            var result = (from ste in _context.FarmingType
                          select new
                          {
                              ste.fmtId,
                              ste.fmtName,
                              Fullname = ste.fmtName + " " + ste.fmtNameInTamil
                          }).ToList();
            int count = result.Count();
            if (count == 0)
            {
                return Ok(new { success = false, Content = result });
            }
            return Ok(new { success = true, Content = result });
        }

        [HttpGet(nameof(GetAllIrrigationFacility))]
        public async Task<ActionResult<IEnumerable<IrrigationFacility>>> GetAllIrrigationFacility()
        {
            var result = (from ste in _context.IrrigationFacility
                          select new
                          {
                              ste.igfId,
                              ste.igfName,
                              Fullname = ste.igfName + " " + ste.igfNameInTamil
                          }).ToList();
            int count = result.Count();
            if (count == 0)
            {
                return Ok(new { success = false, Content = result });
            }
            return Ok(new { success = true, Content = result });
        }

        [HttpGet(nameof(GetAllCrops))]
        public async Task<ActionResult<IEnumerable<Crops>>> GetAllCrops()
        {
            var result = (from crp in _context.Crops
                          select new
                          {
                              crp.crpId,
                              crp.crpName,
                              Fullname = crp.crpName + " " + crp.crpNameInTamil
                          }).ToList();
            int count = result.Count();
            if (count == 0)
            {
                return Ok(new { success = false, Content = result });
            }
            return Ok(new { success = true, Content = result });
        }

        [HttpGet(nameof(GetAllLiveStock))]
        public async Task<ActionResult<IEnumerable<LiveStock>>> GetAllLiveStock()
        {
            var result = (from lsk in _context.LiveStock
                          select new
                          {
                              lsk.lskId,
                              lsk.lskName,
                              Fullname = lsk.lskName + " " + lsk.lskNameInTamil
                          }).ToList();
            int count = result.Count();
            if (count == 0)
            {
                return Ok(new { success = false, Content = result });
            }
            return Ok(new { success = true, Content = result });
        }

        #endregion

        #region Farmer

        [HttpGet(nameof(MobileNumberAlreadyExist))]
        public async Task<ActionResult<IEnumerable<Farmer>>> MobileNumberAlreadyExist(Int64 mobilenumber)
        {
            var result = _context.Farmer.Where(a => a.fmrMobileNo == mobilenumber).ToList();
            int count = result.Count();
            if (count == 0)
            {
                return Ok(new { success = false, Content = result });
            }
            return Ok(new { success = true, Content = result });
        }

        [HttpPost(nameof(AddFarmer))]
        public async Task<ActionResult<Farmer>> AddFarmer(Int64 mobilenumber)
        {
            try
            {
                var frmen = _context.Farmer.FirstOrDefault(e => e.fmrMobileNo == mobilenumber);
                if (frmen == null)
                {
                    Farmer frm = new Farmer();
                    frm.fmrMobileNo = mobilenumber;
                    frm.fmrFarmerId = null;
                    frm.fmrFarmerIdNo = null;
                    frm.fmrStateId = null;
                    frm.fmrCityId = null;
                    frm.fmrTalukId = null;
                    frm.fmrBlockId = null;
                    frm.fmrVillageId = null;
                    frm.fmrPincodeId = null;
                    frm.fmrDeviceId = null;
                    frm.fmrActive = true;
                    frm.fmrCreatedBy = 1;
                    frm.fmrCreatedOn = DateTime.Now;
                    _context.Farmer.Add(frm);
                    await _context.SaveChangesAsync();
                    return new JsonResult(new { code = StatusCodes.Status200OK, type = "Success", message = "Record added successfully", id = frm.fmrId, frm.fmrMobileNo });
                }
                return new JsonResult(new { code = StatusCodes.Status200OK, type = "Failed", message = "No Record Details are not found" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { code = StatusCodes.Status400BadRequest, type = "Failed", message = ex.ToString() });
            }
        }

        [HttpPost(nameof(UpdateFarmer))]
        public async Task<ActionResult<Farmer>> UpdateFarmer(Farmer farmer)
        {
            try
            {
                var frmentity = _context.Farmer.FirstOrDefault(e => e.fmrId == farmer.fmrId);
                if (frmentity != null)
                {
                    frmentity.fmrName = farmer.fmrName;
                    //if (farmer.fmrFarmerId != null)
                    //    frmentity.fmrFarmerId = farmer.fmrFarmerId;
                    //if (farmer.fmrFarmerIdNo != null)
                    //    frmentity.fmrFarmerIdNo = farmer.fmrFarmerIdNo;
                    if (farmer.fmrStateId != 0)
                        frmentity.fmrStateId = farmer.fmrStateId;
                    if (farmer.fmrCityId != 0)
                        frmentity.fmrCityId = farmer.fmrCityId;
                    if (farmer.fmrTalukId != 0)
                        frmentity.fmrTalukId = farmer.fmrTalukId;
                    if (farmer.fmrBlockId != 0)
                        frmentity.fmrBlockId = farmer.fmrBlockId;
                    frmentity.fmrWhatsAppNo = farmer.fmrWhatsAppNo;
                    frmentity.fmrVillageId = farmer.fmrVillageId;
                    frmentity.fmrDeviceId = farmer.fmrDeviceId;
                    frmentity.fmrAddress1 = farmer.fmrAddress1;
                    frmentity.fmrAddress2 = farmer.fmrAddress2;
                    frmentity.fmrAddress3 = farmer.fmrAddress3;
                    if (farmer.fmrPincodeId != 0)
                        frmentity.fmrPincodeId = farmer.fmrPincodeId;
                    frmentity.fmrModifiedBy = 1;
                    frmentity.fmrModifiedOn = DateTime.Now;
                    _context.SaveChanges();
                    return new JsonResult(new { code = StatusCodes.Status200OK, type = "Success", message = "Record updated successfully" });
                }
                return new JsonResult(new { code = StatusCodes.Status200OK, type = "Failed", message = "No Record Details are not found" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { code = StatusCodes.Status400BadRequest, type = "Failed", message = ex.ToString() });
            }
        }        

        [HttpGet(nameof(GetAllFarmers))]
        public async Task<ActionResult<IEnumerable<Farmer>>> GetAllFarmers()
        {
            try
            {
                var result = (from fmr in _context.Farmer
                              select new
                              {
                                  fmr.fmrId,
                                  fmr.fmrMobileNo,
                                  fmr.fmrName,
                                  fmr.fmrStateId,
                                  fmr.fmrCityId,
                                  fmr.fmrAddress1,
                                  fmr.fmrAddress2,
                                  fmr.fmrAddress3,
                                  fmr.fmrPincodeId,
                                  fmr.fmrActive,
                                  fmr.fmrTalukId,
                                  fmr.fmrBlockId,
                                  fmr.fmrDeviceId,
                                  fmr.fmrVillageId,
                                  fmr.fmrWhatsAppNo,
                                  fmr.fmrFarmerId,
                                  fmr.fmrFarmerIdNo
                              }).ToList();
                int count = result.Count();
                if (count == 0)
                {
                    return Ok(new { success = false, Content = result });
                }
                return Ok(new { success = true, Content = result });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet(nameof(GetFarmerById))]
        public async Task<ActionResult<IEnumerable<Farmer>>> GetFarmerById(int fmrId)
        {
            var result = (from fmr in _context.Farmer.Where(fmr => fmr.fmrId == fmrId)
                          select new
                          {
                              fmr.fmrId,
                              fmr.fmrMobileNo,
                              fmr.fmrName,
                              fmr.fmrStateId,
                              fmr.fmrCityId,
                              fmr.fmrAddress1,
                              fmr.fmrAddress2,
                              fmr.fmrAddress3,
                              fmr.fmrPincodeId,
                              fmr.fmrActive,
                              fmr.fmrTalukId,
                              fmr.fmrBlockId,
                              fmr.fmrVillageId,
                              fmr.fmrWhatsAppNo,
                              fmr.fmrFarmerId,
                              fmr.fmrFarmerIdNo,
                              fmr.fmrDeviceId,
                          }).ToList();
            int count = result.Count();
            if (count == 0)
            {
                return Ok(new { success = false, Content = result });
            }
            return Ok(new { success = true, Content = result });
        }

        #endregion

        #region FarmDetails

        [HttpPost(nameof(AddFarmDetails))]
        public async Task<ActionResult<FarmDetails>> AddFarmDetails(FarmDetails farmerDetail)
        {
            try
            {
                int fmdserialNo = 0;
                var id = _context.FarmDetails.Where(frh => frh.fmdFarmerId == farmerDetail.fmdFarmerId);
                if (id.Any())
                    fmdserialNo = (int)id.Max(frh => frh.fmdSno);
                FarmDetails frmdetail = new FarmDetails();
                frmdetail.fmdSno = fmdserialNo + 1;
                frmdetail.fmdFarmerId = farmerDetail.fmdFarmerId;
                frmdetail.fmdStateId = farmerDetail.fmdStateId;
                frmdetail.fmdCityId = farmerDetail.fmdCityId;
                frmdetail.fmdTalukId = farmerDetail.fmdTalukId;
                frmdetail.fmdBlockId = farmerDetail.fmdBlockId;
                frmdetail.fmdCropId = farmerDetail.fmdCropId;
                frmdetail.fmdLiveStockId = farmerDetail.fmdLiveStockId;
                frmdetail.fmdVillageId = farmerDetail.fmdVillageId;
                frmdetail.fmdAddress1 = farmerDetail.fmdAddress1;
                frmdetail.fmdAddress2 = farmerDetail.fmdAddress2;
                frmdetail.fmdAddress3 = farmerDetail.fmdAddress3;
                frmdetail.fmdPincodeId = farmerDetail.fmdPincodeId;
                frmdetail.fmdFarmSize = farmerDetail.fmdFarmSize;
                frmdetail.fmdNoOfPlots = farmerDetail.fmdNoOfPlots;
                frmdetail.fmdIrrigationFacility = farmerDetail.fmdIrrigationFacility;
                frmdetail.fmdFarmingType = farmerDetail.fmdFarmingType;
                frmdetail.fmdActive = true;
                frmdetail.fmdCreatedBy = 1;
                frmdetail.fmdCreatedOn = DateTime.Now;
                _context.FarmDetails.Add(frmdetail);
                await _context.SaveChangesAsync();

                //Update fmrFarmerId and fmrFarmerIdNo
                int frmId = 0;
                string fullnumber = null;
                var farmer = _context.Farmer.FirstOrDefault(e => e.fmrId == farmerDetail.fmdFarmerId);
                if (farmer != null && farmer.fmrName != null && farmer.fmrMobileNo != null)
                {
                    if (farmer.fmrFarmerId == null && farmer.fmrFarmerIdNo == null)
                    {
                        //frmentity.fmrName = farmer.fmrName;
                        frmId = Convert.ToInt32(_context.Farmer.Select(fr => fr.fmrFarmerIdNo).Max());
                        frmId = frmId + 1;
                        fullnumber = "FRM" + DateTime.Now.Year.ToString() + "TN" + (frmId.ToString().PadLeft(7, '0'));
                        farmer.fmrFarmerId = fullnumber;
                        farmer.fmrFarmerIdNo = frmId;
                        _context.SaveChanges();
                    }
                }
                return new JsonResult(new { code = StatusCodes.Status200OK, type = "Success", message = "Record added successfully", id = frmdetail.fmdId, farmerDetail.fmdFarmerId });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { code = StatusCodes.Status400BadRequest, type = "Failed", message = ex.ToString() });
            }
        }

        [HttpPost(nameof(UpdateFarmDetails))]
        public async Task<ActionResult<FarmDetails>> UpdateFarmDetails(FarmDetails farmerDetail)
        {
            try
            {
                var frmdetail = _context.FarmDetails.FirstOrDefault(e => e.fmdId == farmerDetail.fmdId && e.fmdFarmerId == farmerDetail.fmdFarmerId);
                if (frmdetail != null)
                {
                    if (farmerDetail.fmdStateId != 0)
                        frmdetail.fmdStateId = farmerDetail.fmdStateId;
                    frmdetail.fmdCityId = farmerDetail.fmdCityId;
                    if (farmerDetail.fmdTalukId != 0)
                        frmdetail.fmdTalukId = farmerDetail.fmdTalukId;
                    if (farmerDetail.fmdBlockId != 0)
                        frmdetail.fmdBlockId = farmerDetail.fmdBlockId;
                    frmdetail.fmdCropId = farmerDetail.fmdCropId;
                    frmdetail.fmdLiveStockId = farmerDetail.fmdLiveStockId;
                    frmdetail.fmdVillageId = farmerDetail.fmdVillageId;
                    frmdetail.fmdAddress1 = farmerDetail.fmdAddress1;
                    frmdetail.fmdAddress2 = farmerDetail.fmdAddress2;
                    frmdetail.fmdAddress3 = farmerDetail.fmdAddress3;
                    if (farmerDetail.fmdPincodeId != 0)
                        frmdetail.fmdPincodeId = farmerDetail.fmdPincodeId;
                    frmdetail.fmdFarmSize = farmerDetail.fmdFarmSize;
                    frmdetail.fmdNoOfPlots = farmerDetail.fmdNoOfPlots;
                    frmdetail.fmdIrrigationFacility = farmerDetail.fmdIrrigationFacility;
                    frmdetail.fmdFarmingType = farmerDetail.fmdFarmingType;
                    frmdetail.fmdModifiedBy = 1;
                    frmdetail.fmdModifiedOn = DateTime.Now;
                    _context.SaveChanges();
                    return new JsonResult(new { code = StatusCodes.Status200OK, type = "Success", message = "Record updated successfully", farmerDetail.fmdFarmerId });
                }
                return new JsonResult(new { code = StatusCodes.Status200OK, type = "Failed", message = "No Record Details are not found", farmerDetail.fmdFarmerId });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { code = StatusCodes.Status400BadRequest, type = "Failed", message = ex.ToString() });
            }
        }

        [HttpGet(nameof(GetFarmDetailsByFarmerId))]
        public async Task<ActionResult<IEnumerable<FarmDetails>>> GetFarmDetailsByFarmerId(int fmdFarmerId)
        {
            var result = (from frm in _context.FarmDetails.Where(frmh => frmh.fmdFarmerId == fmdFarmerId)
                          select new
                          {
                              frm.fmdId,
                              frm.fmdSno,
                              frm.fmdFarmerId,
                              frm.fmdStateId,
                              frm.fmdCityId,
                              frm.fmdTalukId,
                              frm.fmdBlockId,
                              frm.fmdCropId,
                              frm.fmdLiveStockId,
                              frm.fmdVillageId,
                              frm.fmdAddress1,
                              frm.fmdAddress2,
                              frm.fmdAddress3,
                              frm.fmdPincodeId,
                              frm.fmdFarmSize,
                              frm.fmdNoOfPlots,
                              frm.fmdIrrigationFacility,
                              frm.fmdFarmingType,
                              frm.fmdActive
                          }).ToList();
            int count = result.Count();
            if (count == 0)
            {
                return Ok(new { success = false, Content = result });
            }
            return Ok(new { success = true, Content = result });
        }

        #endregion

        #region FireBase Notification


        [HttpPost(nameof(UpdateMobileDeviceID))]
        public async Task<ActionResult<Farmer>> UpdateMobileDeviceID(string deviceId, int fmrId)
        {
            try
            {
                //string scanningValue = string.Empty;
                var farmer = _context.Farmer.FirstOrDefault(e => e.fmrId == fmrId);
                if (farmer != null)
                {
                    farmer.fmrDeviceId = deviceId;               
                    _context.SaveChanges();
                    return new JsonResult(new { code = StatusCodes.Status200OK, type = "Success", message = "Record updated successfully" });
                }
                else
                    return new JsonResult(new { code = StatusCodes.Status200OK, type = "Failed", message = "No Record Details are not found" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { code = StatusCodes.Status400BadRequest, type = "Failed", message = ex.ToString() });
            }
        }

        [HttpGet(nameof(GetAllNotificationList))]
        public async Task<ActionResult<IEnumerable<PushNotification>>> GetAllNotificationList()
        {
            var result = (from ste in _context.PushNotification
                          select new
                          {
                              ste.pnfName,
                              ste.pnfDescription,
                              //ste.pnfStatus,
                              ste.pnfDateandTime
                          }).ToList();
            int count = result.Count();
            if (count == 0)
            {
                return Ok(new { success = false, Content = result });
            }
            return Ok(new { success = true, Content = result });
        }

        #endregion
    }
}