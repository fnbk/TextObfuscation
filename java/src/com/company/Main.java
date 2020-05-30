package com.company;

public class Main {

    public static void main(String[] args) {
        System.out.println("hello world");
        var text = "Always look on the bright side of life!";

        var manager = new TextManager();
        var result = manager.convert(text);

        System.out.println(String.format("text: %s", text));
        System.out.println(String.format("result: %s", result));
    }
}


