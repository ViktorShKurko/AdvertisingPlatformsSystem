namespace AdvertisingPlatformsSystem.Dto;

public class UploadDto
{
    /// <summary>
    /// Список ошибок
    /// </summary>
    public List<string> Errors { get; set; } = new List<string>();
    
    /// <summary>
    /// Всего строк данных
    /// </summary>
    public ulong TotalRows { get; set; }
    
    /// <summary>
    /// Всего загруженно
    /// </summary>
    public ulong TotalLoaded { get; set; }
    
    /// <summary>
    /// Всего с ошибками
    /// </summary>
    public ulong TotalFail { get; set; }
}