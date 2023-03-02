using System;
using System.Threading.Tasks;
using QMCommunication.Base;
using QMCommunication.QMPalabelCasecode.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace QMCommunication.QMPalabelCasecode
{
    public interface IPalabelCasecodeAppService :
        ICrudAppService<
            PalabelCasecodeDto,
            Guid,
            GetPalabelCasecodeDto,
            CreatePalabelCasecodeDto,
            UpdatePalabelCasecodeDto>
    {

        /// <summary>
        /// 根据开始结束时间条件查询启明接口，并批量插入到数据库中
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ServiceResult<bool>> PalabelCasecodeSearchAndBatchCreate(PalabelCasecodeSearchAndBatchCreateDto input);
    }
}