using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using GoriAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoriAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashboxController : ControllerBase
    {
        private readonly IIncomeRepository<Income> _incomeRep;
        private readonly IExpenseRepository<Expense> _expenseRep;
        private readonly ICashboxRepository<Cashbox> _cashboxRep;
        private readonly IMapper _mapper;
        public CashboxController(IIncomeRepository<Income> incomeRep, IExpenseRepository<Expense> expenseRep, ICashboxRepository<Cashbox> cashboxRep, IMapper mapper)
        {
            _incomeRep = incomeRep;
            _expenseRep = expenseRep;
            _cashboxRep = cashboxRep;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<CashboxModel>> GetCashbox()
        {
            var itemDAL = await _cashboxRep.GetCashbox();
            return _mapper.Map<CashboxModel>(itemDAL);
        }

        [HttpGet("incomes")]
        public async Task<ActionResult<IncomeModel>> GetAllIncomes()
        {
            var itemsDAL = await _incomeRep.ReadAllIncomes();
            var models = new List<IncomeModel>();
            foreach (var item in itemsDAL)
            {
                models.Add(_mapper.Map<IncomeModel>(item));
            }
            return Ok(models);
        }

        [HttpGet("expenses")]
        public async Task<ActionResult<ExpenseModel>> GetAllExpenses()
        {
            var itemsDAL = await _expenseRep.ReadAllExpenses();
            var models = new List<ExpenseModel>();
            foreach (var item in itemsDAL)
            {
                models.Add(_mapper.Map<ExpenseModel>(item));
            }
            return Ok(models);
        }
        [HttpPost("incomes")]
        public async Task<ActionResult> AddIncome(IncomeModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _incomeRep.CreateIncome(_mapper.Map<Income>(model));
            return Ok(model);

        }
    }
}