using AdvertisingPlatformsSystem.Dto;

namespace AdvertisingPlatformsSystem.AgentLocation;

/// <summary>
/// Сервис для работы с данными по агентам и локациям рекламных площадок.
/// </summary>
public interface IAgentLocationService
{
    /// <summary>
    /// Загрузка дынных по агентам.
    /// </summary>
    /// <param name="data">Данные в формате масиива байт.</param>
    /// <returns>Данные и информация о процессе загрузки.</returns>
    UploadDto UploadAgentLocationData(byte[] data);
    
    /// <summary>
    /// Получить список агентов по локации.
    /// </summary>
    /// <param name="location">Локация в формате: /ru/svrd/</param>
    /// <returns>Список имен агентов.</returns>
    IEnumerable<string> GetAgentsByLocations(string location);
}