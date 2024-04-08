// Video class representing a video on YouTube
using System.Collections.Generic;

public class Video
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    // Other properties such as duration, author, etc.
}

// The interface of a remote service.
public interface IThirdPartyYouTubeLib
{
    List<Video> ListVideos();
    Video GetVideoInfo(string id);
    void DownloadVideo(string id);
}

// The concrete implementation of a service connector.
public class ThirdPartyYouTubeClass : IThirdPartyYouTubeLib
{
    public List<Video> ListVideos()
    {
        // Send an API request to YouTube and return list of videos.
        return [];
    }

    public Video GetVideoInfo(string id)
    {
        // Get metadata about the video with the provided id.
        return new Video();
    }

    public void DownloadVideo(string id)
    {
        // Download a video file from YouTube.
    }
}

// Proxy class for caching requests.
public class CachedYouTubeClass : IThirdPartyYouTubeLib
{
    private readonly IThirdPartyYouTubeLib _service;
    private static List<Video> _listCache;
    private static Dictionary<string, Video> _videoCache;
    private static readonly bool _needReset;

    public CachedYouTubeClass(IThirdPartyYouTubeLib service)
    {
        _service = service;
    }

    public List<Video> ListVideos()
    {
        if (_listCache == null || _needReset)
        {
            _listCache = _service.ListVideos();
        }
        return _listCache;
    }

    public Video GetVideoInfo(string id)
    {
        if (_videoCache == null || _needReset)
        {
            if (_videoCache == null)
                _videoCache = [];

            if (!_videoCache.ContainsKey(id))
                _videoCache[id] = _service.GetVideoInfo(id);
        }
        return _videoCache[id];
    }

    public void DownloadVideo(string id)
    {
        if (!_downloadExists(id) || _needReset)
        {
            _service.DownloadVideo(id);
        }
    }

    private bool _downloadExists(string id)
    {
        // Check if the video is already downloaded.
        return false;
    }
}

// Client code
public class YouTubeManager
{
    private readonly IThirdPartyYouTubeLib _service;

    public YouTubeManager(IThirdPartyYouTubeLib service)
    {
        _service = service;
    }

    public void RenderVideoPage(string id)
    {
        var video = _service.GetVideoInfo(id);
        // Render the video page.
    }

    public void RenderListPanel()
    {
        var videos = _service.ListVideos();
        // Render the list of video thumbnails.
    }

    public void ReactOnUserInput()
    {
        RenderVideoPage("videoId");
        RenderListPanel();
    }
}