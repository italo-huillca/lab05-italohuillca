using Lab5_ItaloHuillca.Models;
using Lab5_ItaloHuillca.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab5_ItaloHuillca.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AsistenciasController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public AsistenciasController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_unitOfWork.Repository<Asistencia>().GetAll());

    [HttpGet("{id}")]
    public IActionResult GetById(int id) => Ok(_unitOfWork.Repository<Asistencia>().GetById(id));

    [HttpPost]
    public async Task<IActionResult> Create(Asistencia entity)
    {
        _unitOfWork.Repository<Asistencia>().Add(entity);
        await _unitOfWork.Complete();
        return Ok(entity);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Asistencia entity)
    {
        entity.IdAsistencia = id;
        _unitOfWork.Repository<Asistencia>().Update(entity);
        await _unitOfWork.Complete();
        return Ok(entity);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        _unitOfWork.Repository<Asistencia>().Delete(id);
        await _unitOfWork.Complete();
        return Ok();
    }
}