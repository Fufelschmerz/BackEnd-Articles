namespace Articles.Application.Common.Data.AdvisoryLock;

public interface IAdvisoryLockFactory
{
    /// <summary>
    ///     Создать блокировку по имени
    /// </summary>
    /// <param name="name">Имя блокировки</param>
    /// <returns>Объект блокировки</returns>
    IAdvisoryLock Create(string name);
}