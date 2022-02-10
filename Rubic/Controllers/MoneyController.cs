using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rubic.DbContext;
using Rubic.Models;
using Rubic.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rubic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyController : ControllerBase
    {
        private MoneyBotContext _context;
        private IMapper _mapper;

        public MoneyController(MoneyBotContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("add/{userId}")]
        public async Task<ActionResult> AddMoneyOperation([FromRoute] int userId, [FromBody] MoneyOperation moneyOperation)
        {
            Money money = new Money()
            {
                Sum = moneyOperation.Sum,
                Operation = moneyOperation.Operation.ToLower(),
                DateTime = DateTime.Now,
                UserId = userId
            };

            _context.Add(money);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<MoneyOperation>>> GetMoneyOperations(int userId)
        {
            bool isExistUser = await _context.Users.AnyAsync(h => h.Id == userId);

            if (!isExistUser) return NotFound();

            List<Money> operations = await _context.Moneys.AsNoTracking().Where(h => h.UserId == userId).ToListAsync();

            if (operations == null) return NotFound();

            List<MoneyOperation> moneyOperations = new List<MoneyOperation>();

            for (int i = 0; i < operations.Count; i++)
            {
                moneyOperations.Add(_mapper.Map<MoneyOperation>(operations[i]));
            }

            return moneyOperations;
        }

        [HttpGet("{userId}/{skipCount}/{countMoneyOperations}")]
        public async Task<ActionResult<List<Money>>> GetNewOperations(int userId, int skipCount, int countMoneyOperations) 
        {
            bool isExistUser = await _context.Users.AnyAsync(h => h.Id == userId);

            if (!isExistUser) return NotFound();

            List<Money> operations = await _context.Moneys.AsNoTracking().Where(h => h.UserId == userId).Skip(skipCount).Take(countMoneyOperations).ToListAsync();

            if (operations == null) return NotFound();

            return operations;
        }

    }
}
