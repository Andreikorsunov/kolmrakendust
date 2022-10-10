# Kolm rakendused
## Kirjeldus
See on projekt, kus on kolm mängurakendust, millesse sisenemiseks tuleb esmalt registreeruda või sisse logida, kui sul kontol on juba olemas, andmebaasis peavad olema kasutajad ja nende mängude käigus saadud punktid.
## Mis on tehtud?
Hetkel on kõik mängud tehtud ja töötavad korralikult, olemas on ka andmebaasi andmeid kasutav login.
## Mida on plaanis teha?
Registreerimine koos andmete sisestamisega andmebaasi. Edetabel, kus igalt üksikult kasutajalt võetakse punkte ja selgitatakse välja, kes saavutas kõige rohkem punkte.
## Kuidas autoriseerimine töötab
Sa valid seda nuppu "Logi sisse".

![изображение](https://user-images.githubusercontent.com/77333208/194776730-8000fc35-e27d-4445-9518-6873c1ad8ed6.png)


Peale klõpsamist näete akent, kus peate sisestama olemasoleva andmete nime ja parooli.

![изображение](https://user-images.githubusercontent.com/77333208/194776833-5befb12d-97f0-4516-8cf1-91bd2b5e4e39.png)


Kui sisestad õiged andmed, suunatakse sind järgmisse menüüsse, kus saad juba valida ükskõik millise kolme mängu hulgast ja näha edetabelit.

![pilt](https://user-images.githubusercontent.com/77333208/194815935-25afbf71-cb3c-467b-9cb4-f69ea942cdb0.png)


Kui sisestate valed andmed, neid pole andmebaasis, siis näete teadet "Palun kontrolli sisestatud andmete õigsust!"

![pilt](https://user-images.githubusercontent.com/77333208/194815908-2c183523-6264-433e-b650-e51c2bb11c9f.png)


## Kood
```
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=users;Integrated Security=True;Pooling=False");
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From UserL Where name='" + textBox1.Text + "' and password = '" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();

                StartMenu f2 = new StartMenu();
                f2.Show();
            }
            else
            {
                MessageBox.Show("Palun kontrolli sisestatud andmete õigsust!");
            }
```
