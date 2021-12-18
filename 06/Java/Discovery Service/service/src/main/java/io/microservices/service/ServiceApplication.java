package io.microservices.service;

import org.springframework.beans.factory.annotation.Value;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.client.discovery.EnableDiscoveryClient;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@EnableDiscoveryClient
@RestController
@SpringBootApplication
public class ServiceApplication 
{	
	private static String instanceName;
	
	@Value("${server.port}")
	private static String serverPort;

	public static void main(final String[] args) {		
		SpringApplication.run(ServiceApplication.class, args);

		validateArguments(args);
	}

	@RequestMapping("/")
	public String message(){
		return "Hello from " + instanceName;
	}

	private static void validateArguments(final String[] args){
		if(args.length == 0){
			instanceName = "Execute with parameters";
		}else{
			instanceName = args[0];
		}
	}

}
