using Lab5_ItaloHuillca.Models;
using Lab5_ItaloHuillca.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab5_ItaloHuillca.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EvaluacionesController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public EvaluacionesController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_unitOfWork.Repository<Evaluacion>().GetAll());

    [HttpGet("{id}")]
    public IActionResult GetById(int id) => Ok(_unitOfWork.Repository<Evaluacion>().GetById(id));

    [HttpPost]
    public async Task<IActionResult> Create(Evaluacion entity)
    {
        _unitOfWork.Repository<Evaluacion>().Add(entity);
        await _unitOfWork.Complete();
        return Ok(entity);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Evaluacion entity)
    {
        entity.IdEvaluacion = id;
        _unitOfWork.Repository<Evaluacion>().Update(entity);
        await _unitOfWork.Complete();
        return Ok(entity);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        _unitOfWork.Repository<Evaluacion>().Delete(id);
        await _unitOfWork.Complete();
        return Ok();
    }
}