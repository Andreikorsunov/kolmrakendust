# Kolm rakendused
## Kirjeldus
See on projekt, kus on kolm mängurakendust, millesse sisenemiseks tuleb esmalt registreeruda või sisse logida, kui sul kontol on juba olemas, andmebaasis peavad olema kasutajad ja nende mängude käigus saadud punktid.
## Mis on tehtud?
Hetkel on kõik mängud tehtud ja töötavad korralikult, toimib ka autoriseerimine ja registreerimine andmebaasi abil.

Parooli taastamine e-posti teel
## Mida on plaanis teha?
Parooli taastamine e-posti teel, kus kui sisestate olemasoleva meili, kuvatakse selle konto parool

Registreerimine koos andmete sisestamisega andmebaasi. 

Edetabel, kus igalt üksikult kasutajalt võetakse punkte ja selgitatakse välja, kes saavutas kõige rohkem punkte.

Tabel, kus kuvatakse kõik olemasolevad kontod ilma punktideta (loomulikult ilma paroolideta).

Muutke kujundust veidi, et see parem välja näeks.
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
## Oma funktsioon, mis kontrollib juba olemasolevat kasutajat, kui on duplikaat, siis kontot ei looda, kui ei, siis luuakse.(kontrollib kas posti või login on duplikaat)
```
            var login = textBox1.Text;
            var mail = textBox4.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string addToDB = $"SELECT AndmedID, nimi, email FROM Andmed WHERE nimi = '{login}' OR email = '{mail}'";

            SqlCommand command = new SqlCommand(addToDB, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count > 0)
            {
                MessageBox.Show("Konto on juba olemas!");
                return true;
            }
            else
            {
                return false;
            }
```
## Parooli taastamine
Klõpsake nuppu "Unustan parooli"

![pilt](https://user-images.githubusercontent.com/77333208/196116774-4cee78ef-4d6e-47e8-89f3-9b3f6a2a1fef.png)

Avaneb aken, kus esimene tekstikast vastutab olemasoleva meili sisestamise eest ja teine ​​tekstikast on olemas parooli saamiseks.

![pilt](https://user-images.githubusercontent.com/77333208/196116967-c7d601b7-4cc2-4db7-bf6a-86f39d8d0d81.png)

Sisestan õige e-posti aadressi ja saan kontolt parooli (pärast nuppu Saada parool klõpsamist)

![pilt](https://user-images.githubusercontent.com/77333208/196117155-c1988dc1-86f1-4670-948a-0ae34d648dcb.png)

