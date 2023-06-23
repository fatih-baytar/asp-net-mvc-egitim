let o1 = {
    "Ad": "Fatih",
    "Soyad": "Baytar",
    "Yas": 35,
    "Notlar": [55, 75, 95]
} //JSON = Javascript Object Notation
console.log(o1.Ad);
var toplamNot = 0;
for (let i = 0; i < o1.Notlar.length; i++) {
    toplamNot += o1.Notlar[i]; // toplamNot = toplamNot + o1.Notlar[i]
}
console.log("Toplam Not:" + toplamNot);

const sayilar = [3, 15, 25, 55, 75, 2, 255, 4];

var sayiToplamlari = 0;

for (let i = 0; i < sayilar.length; i++) {
    sayiToplamlari += sayilar[i];
}
console.log("Sayilarin toplamı:", sayiToplamlari);
console.log("Sayıların ortamalası:", sayiToplamlari / sayilar.length);