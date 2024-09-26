using CloudinaryDotNet;
using CloudinaryDotNet.Actions;


public class CloudinaryHelper
{
    private readonly Cloudinary _cloudinary;

    public CloudinaryHelper(IConfiguration configuration)
    {
        
        var cloudName = configuration["Cloudinary:CloudName"];
        var apiKey = configuration["Cloudinary:ApiKey"];
        var apiSecret = configuration["Cloudinary:ApiSecret"];

        if (string.IsNullOrEmpty(cloudName) || string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(apiSecret))
        {
            throw new ArgumentException("Missing Cloudinary configuration settings");
        }

        var account = new Account(cloudName, apiKey, apiSecret);
        _cloudinary = new Cloudinary(account);
        _cloudinary.Api.Secure = true;
    }

    public ImageUploadResult UploadImage(IFormFile file)
    {
        var uploadResult = new ImageUploadResult();

        if (file.Length > 0)
        {
            using (var stream = file.OpenReadStream())
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Quality("auto").FetchFormat("auto")
                };

                uploadResult = _cloudinary.Upload(uploadParams);
            }
        }

        return uploadResult;
    }
}
