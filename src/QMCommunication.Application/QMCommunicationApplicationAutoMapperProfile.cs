using QMCommunication.QMPalabelCasecode;
using QMCommunication.QMPalabelCasecode.Dtos;
using AutoMapper;

namespace QMCommunication
{
    public class QMCommunicationApplicationAutoMapperProfile : Profile
    {
        public QMCommunicationApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<PalabelCasecode, PalabelCasecodeDto>();
            CreateMap<CreatePalabelCasecodeDto, PalabelCasecode>(MemberList.Source);
            CreateMap<UpdatePalabelCasecodeDto, PalabelCasecode>(MemberList.Source);
        }
    }
}
