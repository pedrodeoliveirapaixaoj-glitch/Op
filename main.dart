import 'package:flutter/material.dart';

void main() {
  runApp(Football2026());
}

class Football2026 extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: "Football 2026",
      debugShowCheckedModeBanner: false,
      home: MenuPrincipal(),
    );
  }
}

class MenuPrincipal extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.green,
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [

            Text(
              "⚽ FOOTBALL 2026",
              style: TextStyle(
                fontSize: 35,
                color: Colors.white,
                fontWeight: FontWeight.bold,
              ),
            ),

            SizedBox(height: 40),

            ElevatedButton(
              child: Text("Jogar Partida"),
              onPressed: () {},
            ),

            ElevatedButton(
              child: Text("Carreira"),
              onPressed: () {},
            ),

            ElevatedButton(
              child: Text("Selecionar Times"),
              onPressed: () {},
            ),

          ],
        ),
      ),
    );
  }
}
