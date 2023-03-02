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
        /// ���ݿ�ʼ����ʱ��������ѯ�����ӿڣ����������뵽���ݿ���
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ServiceResult<bool>> PalabelCasecodeSearchAndBatchCreate(PalabelCasecodeSearchAndBatchCreateDto input);
    }
}