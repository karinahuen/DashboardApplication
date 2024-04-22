using DashboardApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace DashboardApplication.Controllers
{
    public class DetailController : Controller
    {
        private readonly ILogger<DetailController> _logger;
        private DetailSearchViewModel detailSearchModel = new DetailSearchViewModel();
        private DashboardViewModel dashboardchModel = new DashboardViewModel();
        public const string SessionDetailSearchDate = "_DetailSearchDate";
        public const string SessionCurrentFilterName = "_DetailSearchCurrentFilterName";

        public DetailController(ILogger<DetailController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //Clear Session
            ClearSession();

            detailSearchModel.SearchDetailList = new List<DashboardViewModel>();

            //List<DashboardViewModel> tenantList = GetDashboardDetail();
            detailSearchModel.SearchDetailList = dashboardchModel.GetDashboardDetail();
            DateTime currentDate = DateTime.Today;
            string DateDesc = currentDate.ToString("yyyy-MM-dd");
            ViewData["currentDate"] = DateDesc;

            //Set Session
            SetSession(DateDesc);


            //Set Sort Order By
            SetSortingOrder("");

            return View(detailSearchModel);
        }

        [HttpPost]
        public IActionResult Index(string FilterDateTextBox)
        {

            detailSearchModel.SearchDetailList = new List<DashboardViewModel>();

            //Set Session
            SetSession(FilterDateTextBox);

            //check the date validation in text box
            detailSearchModel.SearchDetailList = FilterByDateList(FilterDateTextBox);

            ViewData["currentDate"] = FilterDateTextBox;

            //Set Sort Order By
            SetSortingOrder("");


            return View(detailSearchModel);
        }

        public void SetSortingOrder(string sortName)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCurrentFilterName)))
            {
                if(sortName != HttpContext.Session.GetString(SessionCurrentFilterName))
                {
                    SetDefaultSortOrderBy("DESC", "DESC");
                }
                else
                {
                    //set default
                    SetDefaultSortOrderBy("ASC", "DESC");
                }
            }
            else
            {
                //set default
                SetDefaultSortOrderBy("ASC", "DESC");
            }
        }

        public void SetDefaultSortOrderBy(string currentSortOrderBy, string setSortOrderByValue)
        {

            if (ViewBag.SortOrderBy == currentSortOrderBy)
                ViewBag.SortOrderBy = setSortOrderByValue;
            else
                ViewBag.SortOrderBy = currentSortOrderBy;

        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SortFilter(string sortOrderName, string sortOrder)
        {
            ViewBag.SortOrderBy = sortOrder;
            detailSearchModel.SearchDetailList = new List<DashboardViewModel>();

            List<DashboardViewModel> filteredTenantList = new List<DashboardViewModel>();

            //check the current valid search date
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionDetailSearchDate)))
            {
                string? sessionSearchDate = HttpContext.Session.GetString(SessionDetailSearchDate);
                ViewData["currentDate"] = sessionSearchDate;

                //check the date validation in text box
                if (!string.IsNullOrEmpty(sessionSearchDate))
                {
                    filteredTenantList = FilterByDateList(sessionSearchDate);
                }
            }

            //Set Sort Order By
            SetSortingOrder(sortOrderName);

            if (filteredTenantList.Count > 0)
            {
                if (ViewBag.SortOrderBy == "DESC")
                {
                    var descTenantList = from t in filteredTenantList
                                         orderby GetPropertyValue(t, sortOrderName) descending
                                         select t;
                    detailSearchModel.SearchDetailList = descTenantList.ToList();
                }
                else
                {
                    var ascTenantList = from t in filteredTenantList
                                        orderby GetPropertyValue(t, sortOrderName) ascending
                                        select t;
                    detailSearchModel.SearchDetailList = ascTenantList.ToList();
                }
            }

            //Set new session for order by
            HttpContext.Session.SetString(SessionCurrentFilterName, sortOrderName);
       


            return View("Index", detailSearchModel);
        }


        public List<DashboardViewModel> FilterByDateList(string filterValue)
        {
            List<DashboardViewModel> filterByDateLists = new List<DashboardViewModel>();
            List<DashboardViewModel> searchTenantList = dashboardchModel.GetDashboardDetail();

            //check the date validation in text box
            DateTime temp;
            if (DateTime.TryParse(filterValue, out temp))
            {
                temp = DateTime.Parse(filterValue);
                if(searchTenantList != null)
                {
                    IEnumerable<DashboardViewModel> searchDetailQuery =
                    from td in searchTenantList
                    where DateTime.Parse(td.IncomeMonthDate == null? "1900-01-01" : td.IncomeMonthDate) <= temp
                    select td;

                    filterByDateLists = searchDetailQuery.ToList();
                }

            }
            else if (string.IsNullOrEmpty(filterValue))
            {
                filterByDateLists = searchTenantList;
            }

            return filterByDateLists;
        }


        public void SetSession(string value)
        {
            //Set Search Date Textbox value
            HttpContext.Session.SetString(SessionDetailSearchDate, value);
        }

        public void ClearSession()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionDetailSearchDate)) ||
                !string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCurrentFilterName)))
            {
                HttpContext.Session.Clear();
            }
        }

        private static object? GetPropertyValue(object obj, string property)
        {
            System.Reflection.PropertyInfo? propertyInfo = obj.GetType().GetProperty(property);
            return propertyInfo.GetValue(obj, null);
        }
    }
}