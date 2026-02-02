using AuthServiceIN6BV.Application.Interfaces;

namespace AuthServiceIN6BV.Application.Interfaces;

public interface ICloudinaryService
{
    
    Task<String> UploadImageAsync(IFileData imageFile, string fileName);

    Task<bool> DeleteImageAsync(string publicId);
    string GetDefaultAvatarUrl();
    string GetFullIImageUrl(string imagePath);
}