package com.pwr.creator.controller;


import com.pwr.creator.domain.Man;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.client.RestTemplate;

@RestController
public class ManController {

    final private RestTemplate restTemplate;

    public ManController(RestTemplate restTemplate) {
        this.restTemplate = restTemplate;
    }

    @GetMapping("/hello")
    public String greeting(@RequestParam String name) {
        return "Greetings, " + name;
    }

    @GetMapping("/people")
    public ResponseEntity<Man> getMan() {
        Man man = restTemplate.getForObject("https://uinames.com/api/", Man.class);
        return new ResponseEntity<>(man, HttpStatus.OK);
    }
}
