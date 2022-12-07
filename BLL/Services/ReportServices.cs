using BLL.Entities;
using DAL;
using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ReportServices
    {
        public static ReportModel Get(int id)
        {
            var report = DataAccessFactory.ReportDataAccess().Get(id);
            var reportModel = new ReportModel()
            {
                id = report.id,
                post_id = report.post_id,
                user_id = report.user_id,
                desc = report.desc,
                created_at = report.created_at,
                updated_at = report.updated_at
            };
            return reportModel;
        }

        public static List<ReportModel> Get()
        {
            var reportList = DataAccessFactory.ReportDataAccess().Get();
            var reportModelList = new List<ReportModel>();
            foreach(var report in reportList)
            {
                var reportModel = new ReportModel()
                {
                    id = report.id,
                    post_id = report.post_id,
                    user_id = report.user_id,
                    desc = report.desc,
                    created_at = report.created_at,
                    updated_at = report.updated_at
                };
                reportModelList.Add(reportModel);
            }
            return reportModelList;
        }

        public static bool Add(ReportModel reportModel)
        {
            var report = new Report()
            {
                post_id = reportModel.post_id,
                user_id = reportModel.user_id,
                desc = reportModel.desc,
                created_at = reportModel.created_at,
                updated_at = reportModel.updated_at
            };
            return DataAccessFactory.ReportDataAccess().Add(report);
        }

        public static bool Update(ReportModel reportModel)
        {
            var report = new Report()
            {
                id = reportModel.id,
                post_id = reportModel.post_id,
                user_id = reportModel.user_id,
                desc = reportModel.desc,
                created_at = reportModel.created_at,
                updated_at = reportModel.updated_at
            };
            return DataAccessFactory.ReportDataAccess().Update(report);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.ReportDataAccess().Delete(id);
        }

        public static List<ReportModel> GetByPostID(int id)
        {
            var reports = DataAccessFactory.GetReports().Get(id);
            var reportModelList = new List<ReportModel>();
            foreach (var report in reports)
            {
                var reportModel = new ReportModel()
                {
                    id = report.id,
                    user_id = report.user_id,
                    post_id = report.post_id,
                    desc = report.desc,
                    created_at = report.created_at,
                    updated_at = report.updated_at
                };
                reportModelList.Add(reportModel);
            }
            return reportModelList;
        }

        public static bool DeleteByPostID(int id)
        {
            return DataAccessFactory.DeleteReport().DeleteByPostID(id);
        }
    }
}
