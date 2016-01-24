namespace UMC.Models.Constants
{
    public static class ValidationConstants
    {
        public const string SoundcloudUrlRegex = @"^https?:\/\/?(www\.)?(soundcloud.com|snd.sc)\/(.*)\/(.*)(?!https?:)$";
        public const string YoutubeUrlRegex = @"^(https?\:\/\/)?(www\.)?(youtube\.com|youtu\.?be)\/watch\?v=.+(?!https?:)$";
    }
}