using System;
using Microsoft.AspNetCore.Authorization;
using QMCommunication.Base;
using QMCommunication.Permissions;
using QMCommunication.QMPalabelCasecode.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Microsoft.Extensions.Configuration;
using System.Text;
using QMCommunication.QMGeneral;
using Flurl.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using QMCommunication.Enums;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace QMCommunication.QMPalabelCasecode
{
    public class PalabelCasecodeAppService : CrudAppService<PalabelCasecode, PalabelCasecodeDto, Guid, GetPalabelCasecodeDto, CreatePalabelCasecodeDto, UpdatePalabelCasecodeDto>,
        IPalabelCasecodeAppService
    {
        protected override string GetPolicyName { get; set; } = QMCommunicationPermissions.PalabelCasecode.Default;
        protected override string GetListPolicyName { get; set; } = QMCommunicationPermissions.PalabelCasecode.Default;
        protected override string CreatePolicyName { get; set; } = QMCommunicationPermissions.PalabelCasecode.Create;
        protected override string UpdatePolicyName { get; set; } = QMCommunicationPermissions.PalabelCasecode.Update;
        protected override string DeletePolicyName { get; set; } = QMCommunicationPermissions.PalabelCasecode.Delete;

        private readonly IPalabelCasecodeRepository _repository;
        private readonly IConfiguration _configuration;
        private readonly IFreeSql _freeSql;
        public PalabelCasecodeAppService(
            IPalabelCasecodeRepository repository,
            IConfiguration configuration,
            IFreeSql freeSql
            ) :
            base(repository)
        {
            _repository = repository;
            _configuration = configuration;
            _freeSql = freeSql;
        }

        // [Authorize(QMCommunicationPermissions.PalabelCasecode.Default)]
        [Route("PalabelCasecode/PalabelCasecodeSearchAndBatchCreate")]
        public async Task<ServiceResult<bool>> PalabelCasecodeSearchAndBatchCreate(PalabelCasecodeSearchAndBatchCreateDto input)
        {
            ServiceResult<bool> serviceResult = new Base.ServiceResult<bool>();
            serviceResult.OperationSuccess(true);


            DateTime startDate = Convert.ToDateTime(input.reqDateBegin);
            DateTime endDate = Convert.ToDateTime(input.reqDateEnd);

            //获取拼装好的请求地址
            string QMPalabelCasecodeTotalQueryUrl = await GetQMPalabelCasecodeTotalQueryUrl();

            List<PalabelCasecodeDto> list = new List<PalabelCasecodeDto>();

            while (startDate.AddMinutes(input.intervalMinutes) <= endDate)
            {

                try
                {
                    input.reqDateBegin = startDate.ToString("yyyy-MM-dd HH:mm:ss");

                    input.reqDateEnd = startDate.AddMinutes(input.intervalMinutes).AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss");

                    QMGeneralResult jsons = await QMPalabelCasecodeTotalQueryUrl.PostJsonAsync(input).ReceiveJson<QMGeneralResult>();

                    if (jsons.Code == EQMCode.OK)
                    {
                        List<PalabelCasecodeDto> resultList = JsonConvert.DeserializeObject<List<PalabelCasecodeDto>>(jsons.Data.ToString());

                        if (resultList != null && resultList.Count != 0)
                        {
                            list.AddRange(resultList);
                        }

                        string display = string.Format("{0} - {1}", input.reqDateBegin, input.reqDateEnd);

                        Console.WriteLine(display);

                        Console.WriteLine(jsons.Code);

                        Console.WriteLine(jsons.Msg);

                        Console.WriteLine(list.Count);

                        Console.WriteLine(jsons.Data);
                    }

                    if (jsons.Code == EQMCode.Error && jsons.Msg.Contains("过期"))
                    {
                        QMPalabelCasecodeTotalQueryUrl = await GetQMPalabelCasecodeTotalQueryUrl();

                        continue;
                    }
                    if (jsons.Code == EQMCode.Error && jsons.Msg.Contains("大于"))
                    {
                        Console.WriteLine(jsons.Msg);
                        string display = string.Format("{0} - {1}", input.reqDateBegin, input.reqDateEnd);

                        Logger.LogError($"====错过条数{jsons.Msg}=====时间范围{display}======================");

                        startDate = startDate.AddMinutes(input.intervalMinutes);

                        continue;
                    }

                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

                startDate = startDate.AddMinutes(input.intervalMinutes);
            }

            if (list != null)
            {
                list = list.Where(x =>
                {
                    x.CreationTime = DateTime.Now;
                    return true;

                }).ToList();
                await _freeSql.Insert(list).ExecuteSqlBulkCopyAsync();//插入


            }
            return serviceResult;
        }




        private async Task<string> GetQMPalabelCasecodeTotalQueryUrl()
        {

            QMUser qMUsers = new QMUser(_configuration);

            QMUser qmuser = QMUser.EncryptPublicKey();

            QMGeneralResult tokenResult = await QMUser.QMGetTokenUrl.PostJsonAsync(qmuser
                )
                 .ReceiveJson<QMGeneralResult>();

            string QMPalabelCasecodeTotalQueryUrl = string.Format(QMUser.QMPalabelCasecodeTotalQueryUrl, tokenResult.Token);

            return QMPalabelCasecodeTotalQueryUrl;

        }

    }
}
