using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC1.Models;
using MVC1.DAL;
using MVC1.ViewModel;

namespace MVC1.Controllers
{
    public class CustomerBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpContextBase context = controllerContext.HttpContext;
            string ccode = context.Request.Form["txt_CustomerCode"];
            string cname = context.Request.Form["txt_CustomerName"];

            Customer obj = new Customer();
            obj.CustomerCode = ccode;
            obj.CustomerName = cname;

            return obj;
        }
    }
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Load()
        {
            InsertDetails();
            Customer obj = new Customer()
            {
                CustomerCode = "101",
                CustomerName = "Jay"
            };
            if(Request.QueryString["Type"]=="Html")
            return View("Customer", obj);
            else
                return Json(obj, JsonRequestBehavior.AllowGet);

        }

        public JsonResult LoadJson()
        {
            Customer obj = new Customer()
            {
                CustomerCode = "101",
                CustomerName = "Jay"
            };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        public static void InsertDetails()
        {
            CustomerDetail cd = new CustomerDetail()
            {
                CustomerCode = "ABC12347",
                AddressCode = "3",
                Address = "10,Jagannathan Street",
                City = "Chennai"
            };
            CustomerDal dal = new CustomerDal();
            dal.customerDetails.Add(cd);
            dal.SaveChanges();

        }
        public ActionResult Enter()
        {
            CustomerViewModel obj = new CustomerViewModel();
            obj.customer = new Customer();
            CustomerDal dal = new CustomerDal();
            List<Customer> custcol = dal.customers.ToList<Customer>();
            obj.Customers = custcol;
            return View("ClientCustomer", obj);

            //return View("EnterCustomer", new Customer());
            //return View("EnterCustomer");
            //return View("CustomerData");
        }
        //public ActionResult Submit()
        //{
        //    Customer obj = new Customer();
        //    obj.CustomerCode = Request.Form["CustomerCode"];
        //    obj.CustomerName = Request.Form["CustomerName"];

        //    return View("Customer", obj);
        //}
        //public ActionResult Submit(Customer obj)
        //{

        //    return View("Customer", obj);
        //}
        //public ActionResult Submit([ModelBinder(typeof(CustomerBinder))] Customer obj)
        //{
        //    return View("Customer", obj);
        //}

        //public ActionResult Submit(Customer obj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return View("Customer", obj);
        //    }
        //    else
        //    {
        //        return View("ClientCustomer", obj);
        //        //return View("EnterCustomer", obj);
        //    }
        //}
        public ActionResult Submit()
        {
            CustomerViewModel vm = new CustomerViewModel();
            Customer obj = new Customer();
            obj.CustomerCode = Request.Form["customer.CustomerCode"].ToString();
            obj.CustomerName = Request.Form["customer.CustomerName"].ToString();

            if (ModelState.IsValid)
            {
                CustomerDal cdal = new CustomerDal();
                
                cdal.customers.Add(obj);//memory
                cdal.SaveChanges();
                List<Customer> custcol = cdal.customers.ToList<Customer>();
                vm.Customers = custcol;
                //vm.customer = new Customer();
                
            }
             else
            {
                vm.customer = obj;//Persist the values
            }
            return View("ClientCustomer", vm);

        }
        public ActionResult GoToSearch()
        {
            CustomerViewModel vm = new CustomerViewModel();
            vm.customer = new Customer();
            vm.Customers = new List<Customer>();
            return View("CustomerSearch", vm);
        }
        public ActionResult Search()
        {
            CustomerViewModel obj = new CustomerViewModel();
            obj.customer = new Customer();
            CustomerDal dal = new CustomerDal();
            string name = Request.Form["txt_CustomerName"].ToString();
            List<Customer> custcol = (from x in dal.customers
                                     where x.CustomerName == name
                                     select x).ToList<Customer>();
            obj.Customers = custcol;
            return View("CustomerSearch",obj);
        }

        public ActionResult Multi()
        {
            Customer obj = new Customer();
            return View("MultiButton", obj);
        }
        public ActionResult EvalButton(Customer obj,string save, string delete)
        {
            if (!string.IsNullOrEmpty(save))
            {
                ViewBag.Msg = "Save Button Clicked";
            }
            else if (!string.IsNullOrEmpty(delete))
            {
                ViewBag.Msg = "Delete Button Clicked";
            }
            return View("Customer", obj);
        }
        [HttpPost]
        public ActionResult SaveFrm(Customer obj)
        {
            ViewBag.Msg = "Customer Clicked the save button";
            return View("Customer", obj);
        }

        [HttpPost]
        public ActionResult DeleteFrm(Customer obj)
        {
            ViewBag.Msg = "Customer Clicked the delete button";
            return View("Customer", obj);
        }


    }


}