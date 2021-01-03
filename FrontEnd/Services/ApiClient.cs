using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ConferenceDTO;

namespace FrontEnd.Services
{
    public class ApiClient : IApiClient
    {
        private const string AttendeesUri = "/api/attendees";
        private const string SessionsUri = "/api/sessions";
        private const string SpeakersUri = "/api/speakers";
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<SessionResponse>> GetSessionsAsync()
        {
            var response = await _httpClient.GetAsync($"{SessionsUri}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<List<SessionResponse>>();
        }

        public async Task<SessionResponse> GetSessionAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{SessionsUri}/{id}");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<SessionResponse>();
        }

        public async Task<List<SpeakerResponse>> GetSpeakersAsync()
        {
            var response = await _httpClient.GetAsync($"{SpeakersUri}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<List<SpeakerResponse>>();
        }

        public async Task<SpeakerResponse> GetSpeakerAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{SpeakersUri}/{id}");

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<SpeakerResponse>();
        }

        public async Task PutSessionAsync(Session session)
        {
            var response = await _httpClient.PutAsJsonAsync($"{SessionsUri}", session);
            response.EnsureSuccessStatusCode();
        }

        public async Task<bool> AddAttendeeAsync(Attendee attendee)
        {
            var response = await _httpClient.PostAsJsonAsync(AttendeesUri,
                attendee);
            if (response.StatusCode == HttpStatusCode.Conflict)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();
            return true;
        }

        public async Task<AttendeeResponse> GetAttendeeAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            var response = await _httpClient.GetAsync($"{AttendeesUri}/{name}");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<AttendeeResponse>();
        }

        public async Task DeleteSessionAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{SessionsUri}/{id}");

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return;
            }

            response.EnsureSuccessStatusCode();
        }
    }
}