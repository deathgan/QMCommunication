using QMCommunication.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace QMCommunication.QMPalabelCasecode
{

    public class PalabelCasecode : FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 生产线
        /// </summary>
        public string AssemblyLineCode { get; set; }
        /// <summary>
        /// 生产线名称
        /// </summary>
        public string AssemblyLineName { get; set; }
        /// <summary>
        /// 包装数-每箱数
        /// </summary>
        public int Casecnt { get; set; }
        /// <summary>
        /// 发货人
        /// </summary>
        public string Consignor { get; set; }
        /// <summary>
        /// 发货人描述
        /// </summary>
        public string ConsignorDescription { get; set; }
        /// <summary>
        /// 发货时间
        /// </summary>
        public DateTime? ConsignorTime { get; set; }
        /// <summary>
        /// 客户代码
        /// </summary>
        public string CusCode { get; set; }
        /// <summary>
        /// 出库批次号
        /// </summary>
        public string DeliveryBatchNo { get; set; }
        /// <summary>
        /// 显示类型
        /// </summary>
        public int DisplayType { get; set; }
        /// <summary>
        /// 文件类型
        /// </summary>
        public string DocumentType { get; set; }
        public string GenerateStyle { get; set; }
        /// <summary>
        /// 看板号
        /// </summary>
        public string KanbanCode { get; set; }
        /// <summary>
        /// 标签号
        /// </summary>
        public string KanbanLabel { get; set; }
        /// <summary>
        /// 行项号
        /// </summary>
        public string KanbanLineno { get; set; }
        /// <summary>
        /// 看板状态
        /// </summary>
        public string KanbanStatus { get; set; }
        /// <summary>
        /// INB收货看板,OUT出库看板
        /// 看板类型
        /// </summary>
        public string KanbanType { get; set; }
        /// <summary>
        /// 看板用途
        /// </summary>
        public string KanbanUse { get; set; }
        /// <summary>
        /// 零件号
        /// </summary>
        public string MtlCode { get; set; }
        /// <summary>
        /// 零件名称
        /// </summary>
        public string MtlName { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public string OwnerCode { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string OwnerName { get; set; }
        /// <summary>
        /// 计划到货时间
        /// </summary>
        public DateTime? PlanArrivalTime { get; set; }
        /// <summary>
        /// 需求数
        /// </summary>
        public int PlanQty { get; set; }
        /// <summary>
        /// 工厂
        /// </summary>
        public string Plant { get; set; }
        /// <summary>
        /// 进度批次号
        /// </summary>
        public string ProgressBatchNo { get; set; }
        /// <summary>
        /// 收货数
        /// </summary>
        public int ReceiveQty { get; set; }
        /// <summary>
        /// 反冲数
        /// </summary>
        public int RecoilQty { get; set; }
        /// <summary>
        /// 要货时间
        /// </summary>
        public DateTime? ReqDate { get; set; }
        /// <summary>
        /// 源库位
        /// </summary>
        public string SLoc { get; set; }
        /// <summary>
        /// 仓库
        /// </summary>
        public string WWhCode { get; set; }

        public string SZoneCode { get; set; }

        public string SZoneName { get; set; }

        public string SZoneNo { get; set; }
        /// <summary>
        /// 发货数
        /// </summary>
        public int SendQty { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public string SupCode { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string SupName { get; set; }
        /// <summary>
        /// 目标仓库
        /// </summary>
        public string TWhCode { get; set; }
        /// <summary>
        /// 目标存储区
        /// </summary>
        public string TZoneCode { get; set; }
        public string TZoneName { get; set; }
        public string TZoneNo { get; set; }

        public string TargetLocCode { get; set; }
        public string TargetWhCode { get; set; }

        protected PalabelCasecode()
        {
        }

        public PalabelCasecode(
            Guid id,
            string assemblyLineCode,
            string assemblyLineName,
            int casecnt,
            string consignor,
            string consignorDescription,
            DateTime? consignorTime,
            string cusCode,
            string deliveryBatchNo,
            int displayType,
            string documentType,
            string generateStyle,
            string kanbanCode,
            string kanbanLabel,
            string kanbanLineno,
            string kanbanStatus,
            string kanbanType,
            string kanbanUse,
            string mtlCode,
            string mtlName,
            string ownerCode,
            string ownerName,
            DateTime? planArrivalTime,
            int planQty,
            string plant,
            string progressBatchNo,
            int receiveQty,
            int recoilQty,
            DateTime? reqDate,
            string sLoc,
            string wWhCode,
            string sZoneCode,
            string sZoneName,
            string sZoneNo,
            int sendQty,
            string supCode,
            string supName,
            string tWhCode,
            string tZoneCode,
            string tZoneName,
            string tZoneNo,
            string targetLocCode,
            string targetWhCode
        ) : base(id)
        {
            AssemblyLineCode = assemblyLineCode;
            AssemblyLineName = assemblyLineName;
            Casecnt = casecnt;
            Consignor = consignor;
            ConsignorDescription = consignorDescription;
            ConsignorTime = consignorTime;
            CusCode = cusCode;
            DeliveryBatchNo = deliveryBatchNo;
            DisplayType = displayType;
            DocumentType = documentType;
            GenerateStyle = generateStyle;
            KanbanCode = kanbanCode;
            KanbanLabel = kanbanLabel;
            KanbanLineno = kanbanLineno;
            KanbanStatus = kanbanStatus;
            KanbanType = kanbanType;
            KanbanUse = kanbanUse;
            MtlCode = mtlCode;
            MtlName = mtlName;
            OwnerCode = ownerCode;
            OwnerName = ownerName;
            PlanArrivalTime = planArrivalTime;
            PlanQty = planQty;
            Plant = plant;
            ProgressBatchNo = progressBatchNo;
            ReceiveQty = receiveQty;
            RecoilQty = recoilQty;
            ReqDate = reqDate;
            SLoc = sLoc;
            WWhCode = wWhCode;
            SZoneCode = sZoneCode;
            SZoneName = sZoneName;
            SZoneNo = sZoneNo;
            SendQty = sendQty;
            SupCode = supCode;
            SupName = supName;
            TWhCode = tWhCode;
            TZoneCode = tZoneCode;
            TZoneName = tZoneName;
            TZoneNo = tZoneNo;
            TargetLocCode = targetLocCode;
            TargetWhCode = targetWhCode;
        }
    }
}
