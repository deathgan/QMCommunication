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

            QMUser qMUser = new QMUser(_configuration);

            DateTime startDate = Convert.ToDateTime(input.reqDateBegin);
            DateTime endDate = Convert.ToDateTime(input.reqDateEnd);

            //��ȡƴװ�õ������ַ
            string QMPalabelCasecodeTotalQueryUrl = await QMUser.GetFormatUrl(QMUser.QMPalabelCasecodeTotalQueryUrl);

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

                    if (jsons.Code == EQMCode.Error && jsons.Msg.Contains("����"))
                    {
                        QMPalabelCasecodeTotalQueryUrl = await QMUser.GetFormatUrl(QMUser.QMPalabelCasecodeTotalQueryUrl);

                        continue;
                    }
                    if (jsons.Code == EQMCode.Error && jsons.Msg.Contains("����"))
                    {
                        Console.WriteLine(jsons.Msg);
                        string display = string.Format("{0} - {1}", input.reqDateBegin, input.reqDateEnd);

                        Logger.LogError($"====�������{jsons.Msg}=====ʱ�䷶Χ{display}======================");

                        startDate = startDate.AddMinutes(input.intervalMinutes);

                        continue;
                    }

                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

                startDate = startDate.AddMinutes(input.intervalMinutes);

                //����������һ��
                if (list != null && list.Count >= 20000)
                {
                    list = list.Where(x =>
                    {
                        x.CreationTime = DateTime.Now;
                        return true;

                    }).ToList();
                    await _freeSql.Insert(list).ExecuteSqlBulkCopyAsync();//����

                    list = new List<PalabelCasecodeDto>();

                    Console.WriteLine("===================�Ѳ���������========================");

                }

            }

            if (list != null)
            {
                list = list.Where(x =>
                {
                    x.CreationTime = DateTime.Now;
                    return true;

                }).ToList();
                await _freeSql.Insert(list).ExecuteSqlBulkCopyAsync();//����


            }
            return serviceResult;
        }



        // [Authorize(QMCommunicationPermissions.PalabelCasecode.Default)]
        [Route("PalabelCasecode/PalabelCasecodeGetTotalCount")]
        public async Task<ServiceResult<int>> PalabelCasecodeGetTotalCount(PalabelCasecodeSearchAndBatchCreateDto input)
        {
            ServiceResult<int> serviceResult = new Base.ServiceResult<int>();
            serviceResult.OperationSuccess(0);

            QMUser qMUser = new QMUser(_configuration);

            //��ȡƴװ�õ������ַ
            string QMPalabelCasecodeTotalQueryNumUrl = await QMUser.GetFormatUrl(QMUser.QMPalabelCasecodeTotalQueryNumUrl);


            try
            {

                QMGeneralResult jsons = await QMPalabelCasecodeTotalQueryNumUrl.PostJsonAsync(input).ReceiveJson<QMGeneralResult>();

                if (jsons.Code == EQMCode.OK)
                {
                    serviceResult.Data = jsons.Data == null ? 0 : Convert.ToInt32(jsons.Data);

                }

                if (jsons.Code == EQMCode.Error && jsons.Msg.Contains("����"))
                {
                    QMPalabelCasecodeTotalQueryNumUrl = await QMUser.GetFormatUrl(QMUser.QMPalabelCasecodeTotalQueryNumUrl);
                }


            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }



            return serviceResult;
        }





    }
}
