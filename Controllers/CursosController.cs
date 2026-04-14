using Lab5_ItaloHuillca.Models;
using Lab5_ItaloHuillca.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab5_ItaloHuillca.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CursosController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public CursosController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_unitOfWork.Repository<Curso>().GetAll());

    [HttpGet("{id}")]
    public IActionResult GetById(int id) => Ok(_unitOfWork.Repository<Curso>().GetById(id));

    [HttpPost]
    public async Task<IActionResult> Create(Curso entity)
    {
        _unitOfWork.Repository<Curso>().Add(entity);
        await _unitOfWork.Complete();
        return Ok(entity);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Curso entity)
    {
        entity.IdCurso = id;
        _unitOfWork.Repository<Curso>().Update(entity);
        await _unitOfWork.Complete();
        return Ok(entity);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        _unitOfWork.Repository<Curso>().Delete(id);
        await _unitOfWork.Complete();
        return Ok();
    }
}