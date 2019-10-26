package com.pwr.edu.project.domain;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import lombok.AllArgsConstructor;
import lombok.Data;

import java.io.Serializable;

@Data
public class Man implements Serializable {
    private String name;
    private String surname;
    private String gender;
    private String religion;
}