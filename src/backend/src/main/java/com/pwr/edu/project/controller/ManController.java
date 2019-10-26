package com.pwr.edu.project.controller;

import com.pwr.edu.project.domain.Man;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.client.RestTemplate;

@RestController
@RequestMapping("/people")
public class ManController {

    private final RestTemplate restTemplate;

    public ManController(RestTemplate restTemplate) {
        this.restTemplate = restTemplate;
    }

    @GetMapping
    public ResponseEntity<Man> getJedi() {
        Man man = restTemplate.getForObject("https://uinames.com/api/", Man.class);
        return new ResponseEntity<>(man, HttpStatus.OK);
    }

}
