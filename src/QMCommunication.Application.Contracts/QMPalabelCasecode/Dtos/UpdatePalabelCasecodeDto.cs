using QMCommunication.Enums;
using System;
using System.ComponentModel;

namespace QMCommunication.QMPalabelCasecode.Dtos
{
    [Serializable]
    public class UpdatePalabelCasecodeDto
    {
        public string AssemblyLineCode { get; set; }

        public string AssemblyLineName { get; set; }

        public int Casecnt { get; set; }

        public string Consignor { get; set; }

        public string ConsignorDescription { get; set; }

        public DateTime ConsignorTime { get; set; }

        public string CusCode { get; set; }

        public string DeliveryBatchNo { get; set; }

        public int DisplayType { get; set; }

        public string DocumentType { get; set; }

        public string GenerateStyle { get; set; }

        public string KanbanCode { get; set; }

        public string KanbanLabel { get; set; }

        public string KanbanLineno { get; set; }

        public EKanbanStatus KanbanStatus { get; set; }

        public EKanbanType KanbanType { get; set; }

        public string KanbanUse { get; set; }

        public string MtlCode { get; set; }

        public string MtlName { get; set; }

        public string OwnerCode { get; set; }

        public string OwnerName { get; set; }

        public DateTime PlanArrivalTime { get; set; }

        public int PlanQty { get; set; }

        public string Plant { get; set; }

        public string ProgressBatchNo { get; set; }

        public int ReceiveQty { get; set; }

        public int RecoilQty { get; set; }

        public DateTime ReqDate { get; set; }

        public string SLoc { get; set; }

        public string WWhCode { get; set; }

        public string SZoneCode { get; set; }

        public string SZoneName { get; set; }

        public string SZoneNo { get; set; }

        public int SendQty { get; set; }

        public string SupCode { get; set; }

        public string SupName { get; set; }

        public string TWhCode { get; set; }

        public string TZoneCode { get; set; }

        public string TZoneName { get; set; }

        public string TZoneNo { get; set; }

        public string TargetLocCode { get; set; }

        public string TargetWhCode { get; set; }
    }
}