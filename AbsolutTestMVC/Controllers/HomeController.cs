using AbsolutTestMVC.Models;
using AbsolutTestMVC.Models.Db;
using AbsolutTestMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AbsolutTestMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAbsolutDataRepository _absolutDataRepository;
        private readonly AbsolutTestSetting _setting;

        public HomeController(
                ILogger<HomeController> logger,
                IAbsolutDataRepository absolutDataRepository,
                IOptions<AbsolutTestSetting> setting)
        {
            _logger = logger;
            _absolutDataRepository = absolutDataRepository;
            _setting = setting.Value;
        }
        /// <summary>
        /// Метод возвращает view Index, с параметрами отображения.
        /// </summary>
        /// <param name="productPage"></param>
        /// <returns></returns>
        public ViewResult Index(int productPage=1)
        {
            return View(new ProductListViewModel
            {
                AbsolutDatas = _absolutDataRepository.GetAbsolutDatas().Skip((productPage - 1) * _setting.PageSize).Take(_setting.PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = _setting.PageSize,
                    TotalItems = 100
                },
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
