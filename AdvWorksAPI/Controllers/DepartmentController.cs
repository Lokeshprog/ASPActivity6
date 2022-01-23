using AdvWorksBL;
using AdvWorksDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdvWorksAPI.Controllers
{
    public class DepartmentController : ApiController
    {

        //Getting List of all Departments
        [HttpGet]
        public HttpResponseMessage GetAllDeptDetails()
        {
            try
            {
                AdvWorksBusinessLayer blObj = new AdvWorksBusinessLayer();
                List<DeptDetailsDTO> lstOfDept = blObj.GetAllDepts();
                if (lstOfDept.Count > 0)
                    return Request.CreateResponse(HttpStatusCode.OK, lstOfDept);
                else
                    return Request.CreateResponse(HttpStatusCode.OK, "No Dept Details");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Getting List of Departments using Department Group Name
        [HttpGet]
        public HttpResponseMessage GetDeptDetails(string deptGroupName)
        {
            try
            {
                AdvWorksBusinessLayer blObj = new AdvWorksBusinessLayer();
                List<DeptDetailsDTO> lstOfDept = blObj.SearchDept(deptGroupName);
                if (lstOfDept.Count > 0)
                    return Request.CreateResponse(HttpStatusCode.OK, lstOfDept);
                else
                    return Request.CreateResponse(HttpStatusCode.OK, "No Dept Details");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Adding New Department
        [HttpPost]
        public HttpResponseMessage AddNewDept(DeptDetailsDTO newDeptObj)
        {
            try
            {
                AdvWorksBusinessLayer blObj = new AdvWorksBusinessLayer();
                int newDeptId = 0;
                int retValue = blObj.AddNewDept(newDeptObj, out newDeptId);
                if (retValue == 1)
                    return Request.CreateResponse(HttpStatusCode.OK, "Department added successfully" + newDeptId);
                else
                    return Request.CreateResponse(HttpStatusCode.OK, "Department not added.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex.Message);
            }
        }

        // Getting List Of All Poducts
        [HttpGet]
        public HttpResponseMessage GetPoductDetails()
        {
            try
            {
                AdvWorksBusinessLayer blObj = new AdvWorksBusinessLayer();
                List<ProductsDTO> listOfProducts = blObj.FetchAllProductsUsingEF();
                if (listOfProducts.Count > 0)
                    return Request.CreateResponse(HttpStatusCode.OK, listOfProducts);
                else
                    return Request.CreateResponse(HttpStatusCode.OK, "Department Details Not Found");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // Getting List Of Products Whose Unit Price is Greater than 10 USD
        [HttpGet]
        public HttpResponseMessage GetAllProductDetails()
        {
            try
            {
                AdvWorksBusinessLayer blObj = new AdvWorksBusinessLayer();
                List<ProductsDTO> listOfProducts = blObj.GetAllProducts();
                if (listOfProducts.Count > 0)
                    return Request.CreateResponse(HttpStatusCode.OK, listOfProducts);
                else
                    return Request.CreateResponse(HttpStatusCode.OK, "Department Details Not Found");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
