package com.pwr.creator.controller;


import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class ManController {


    @GetMapping("/hello")
    public String greeting(@RequestParam String name) {
        return "Greetings, " + name;
    }
}
