using CrudMasterDetail.Data;
using CrudMasterDetail.Models;
using CrudMasterDetail.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudMasterDetail.Controllers
{
    public class InvoiceDetailController : Controller
    {
        private readonly InvoiceContext _context;
        public InvoiceDetailController(InvoiceContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var vm = new InvoiceDetailsViewModels();
            vm.InvoiceDetails = new List<Models.InvoiceDetail>();
            
            ViewBag.Lista = new SelectList(_context.CustomerTypes.ToList(), "Id", "Description");

            InvoiceDetail row1 = new InvoiceDetail();

            vm.InvoiceDetails.Add(row1);
            
            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InvoiceDetailsViewModels model)
        {
            if (ModelState.IsValid)
            {

                ViewBag.Lista = new SelectList(_context.CustomerTypes.ToList(), "Id", "Description");

                var invoiceMaster = new Invoice
                {
                    CustomerId = model.CustomerId,
                    Total = model.Total,
                    TotalItbis = model.TotalItbis,
                    SubTotal = model.SubTotal
                };

                _context.Invoices.Add(invoiceMaster);
                await _context.SaveChangesAsync();

                foreach (var item in model.InvoiceDetails)
                {
                    var invoiceDetails = new InvoiceDetail
                    {
                        CustomerId = model.CustomerId,
                        Qty = item.Qty,
                        Price = item.Price,
                        TotalItbis = item.TotalItbis,
                        SubTotal = item.SubTotal,
                        Total = item.Total
                    };

                    _context.InvoiceDetails.Add(invoiceDetails);
                }
                await _context.SaveChangesAsync();

                //return RedirectToAction("Create");
                return RedirectToAction("Index", "Invoices");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Invoices.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
    }
}