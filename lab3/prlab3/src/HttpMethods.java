import java.io.BufferedReader;
import java.io.DataOutputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;

import javax.net.ssl.HttpsURLConnection;

public class HttpMethods {

    private final String USER_AGENT = "Mozilla/5.0";

    public static void main(String[] args) throws Exception {

        HttpMethods http = new HttpMethods();

        System.out.println("Http GET Method");
        http.sendGet();

        System.out.println("\nHttp POST Method");
        http.sendPost();

        System.out.println("\nHttp PUT Method");
        http.sendPut();

        System.out.println("\nHttp DELETE Method");
        http.sendDelete();

        System.out.println("\nHttp PATCH Method");
        http.sendPatch();

    }

    //Http Get Request (page 2 of users)
    private void sendGet() throws Exception {

        String url = "https://reqres.in/api/users?page=2";

        URL obj = new URL(url);
        HttpURLConnection con = (HttpURLConnection) obj.openConnection();

        //Setting request method
        con.setRequestMethod("GET");

        //Request header
        con.setRequestProperty("User-Agent", USER_AGENT);

        int responseCode = con.getResponseCode();
        System.out.println("\n'GET' URL: " + url);
        System.out.println("Response Code: " + responseCode);

        BufferedReader in = new BufferedReader(
                new InputStreamReader(con.getInputStream()));
        String inputLine;
        StringBuffer response = new StringBuffer();

        while ((inputLine = in.readLine()) != null) {
            response.append(inputLine);
        }
        in.close();

        //Result
        System.out.println(response.toString());

    }

    //Http Post Request (succesful login)
    private void sendPost() throws Exception {

        String url = "https://reqres.in/api/login";
        URL obj = new URL(url);
        HttpsURLConnection con = (HttpsURLConnection) obj.openConnection();

        //Request header
        con.setRequestMethod("POST");
        con.setRequestProperty("User-Agent", USER_AGENT);
        con.setRequestProperty("Accept-Language", "en-US,en;q=0.5");

        String urlParameters = "email=peter@klaven&password=cityslicka";

        //Sending Post Request
        con.setDoOutput(true);
        DataOutputStream wr = new DataOutputStream(con.getOutputStream());
        wr.writeBytes(urlParameters);
        wr.flush();
        wr.close();

        int responseCode = con.getResponseCode();
        System.out.println("\n'POST' URL: " + url);
        System.out.println("'POST' parameters: " + urlParameters);
        System.out.println("Response Code: " + responseCode);

        BufferedReader in = new BufferedReader(new InputStreamReader(con.getInputStream()));
        String inputLine;
        StringBuffer response = new StringBuffer();

        while ((inputLine = in.readLine()) != null) {
            response.append(inputLine);
        }
        in.close();

        //Result
        System.out.println(response.toString());

    }

    //Http Put Request (user insert)
    private void sendPut() throws Exception {

        String url = "https://reqres.in/api/users/4";
        URL obj = new URL(url);
        HttpsURLConnection con = (HttpsURLConnection) obj.openConnection();

        //Request header
        con.setRequestMethod("PUT");
        con.setRequestProperty("User-Agent", USER_AGENT);
        con.setRequestProperty("Accept-Language", "en-US,en;q=0.5");

        String urlParameters = "name=John&job=driver";

        // Send post request
        con.setDoOutput(true);
        DataOutputStream wr = new DataOutputStream(con.getOutputStream());
        wr.writeBytes(urlParameters);
        wr.flush();
        wr.close();

        int responseCode = con.getResponseCode();
        System.out.println("\n'PUT' URL: " + url);
        System.out.println("'PUT' parameters: " + urlParameters);
        System.out.println("Response Code: " + responseCode);

        BufferedReader in = new BufferedReader(new InputStreamReader(con.getInputStream()));
        String inputLine;
        StringBuffer response = new StringBuffer();

        while ((inputLine = in.readLine()) != null) {
            response.append(inputLine);
        }
        in.close();

        //Result
        System.out.println(response.toString());

    }


    //Http Delete Request (user delete)
    private void sendDelete() throws Exception {

        String url = "https://reqres.in/api/users/4";

        URL obj = new URL(url);
        HttpURLConnection con = (HttpURLConnection) obj.openConnection();

        //Setting request method
        con.setRequestMethod("DELETE");


        //Request header
        con.setRequestProperty("User-Agent", USER_AGENT);

        int responseCode = con.getResponseCode();
        System.out.println("\n'DELETE' URL: " + url);
        System.out.println("Response Code: " + responseCode);

        BufferedReader in = new BufferedReader(
                new InputStreamReader(con.getInputStream()));
        String inputLine;
        StringBuffer response = new StringBuffer();

        while ((inputLine = in.readLine()) != null) {
            response.append(inputLine);
        }
        in.close();

        //Result
        System.out.println(response.toString());


    }


    // Http Patch Request
    private void sendPatch() throws Exception {

        String url = "https://reqres.in/api/users/4";
        URL obj = new URL(url);
        HttpsURLConnection con = (HttpsURLConnection) obj.openConnection();

        //Request header
        con.setRequestMethod("POST");
        con.setRequestProperty("X-HTTP-Method-Override", "PATCH");
        con.setRequestProperty("User-Agent", USER_AGENT);
        con.setRequestProperty("Accept-Language", "en-US,en;q=0.5");

        String urlParameters = "name=John&job=driver";

        //Sending Post Request
        con.setDoOutput(true);
        DataOutputStream wr = new DataOutputStream(con.getOutputStream());
        wr.writeBytes(urlParameters);
        wr.flush();
        wr.close();

        int responseCode = con.getResponseCode();
        System.out.println("\n'PATCH' URL: " + url);
        System.out.println("'PATCH' parameters: " + urlParameters);
        System.out.println("Response Code: " + responseCode);

        BufferedReader in = new BufferedReader(new InputStreamReader(con.getInputStream()));
        String inputLine;
        StringBuffer response = new StringBuffer();

        while ((inputLine = in.readLine()) != null) {
            response.append(inputLine);
        }
        in.close();

        //Result
        System.out.println(response.toString());

    }


}