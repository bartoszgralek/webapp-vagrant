package com.pwr.creator.controller;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/people")
public class ManController {

    @GetMapping
    public String getMessage() {
        return "Hello";
    }

}
