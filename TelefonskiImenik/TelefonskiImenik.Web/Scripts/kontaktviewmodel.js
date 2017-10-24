var Status = {
    Nepromijenjeno: 0,
    Dodano: 1,
    Promijenjeno: 2,
    Izbrisano: 3
};


var mapiranjeBrojeva = {
    'Brojevi': {
        key: function (broj) {
            return ko.utils.unwrapObservable(broj.BrojId);
        },
        create: function (options) {
            return new BrojViewModel(options.data);
        }
    }
};

BrojViewModel = function (data) {
    var self = this;
    ko.mapping.fromJS(data, mapiranjeBrojeva, self);

    self.promjeneUBroju = function () {
        if (self.Status() != Status.Dodano) {
            self.Status(Status.Promijenjeno);
        }
        return true;
    };
};


KontaktViewModel = function (data) {
    var self = this;
    ko.mapping.fromJS(data, mapiranjeBrojeva, self);

    self.spremi = function () {
        $.ajax({
            url: "/Kontakt/Spremi/",
            type: "POST",
            data: ko.toJSON(self),
            contentType: "application/json",
            success: function (data) {
                if (data.kontaktViewModel != null)
                    ko.mapping.fromJS(data.kontaktViewModel, {}, self);

                if (data.newLocation != null)
                    window.location = data.newLocation;
            }
        });
    },


        self.promjeneUKontaktu = function () {
            if (self.Status() != Status.Dodano) {
                self.Status(Status.Promijenjeno);
            }

            return true;
        },

        self.dodavanjeBroja = function () {
            var broj = new BrojViewModel({ BrojId: 0, SadrzajBroja: "", TipBroja: "", Opis: "", Status: Status.Dodano });
            self.Brojevi.push(broj);
        },

        self.izbrisiBroj = function (broj) {
            self.Brojevi.remove(this);

            if (broj.BrojId() > 0 && self.BrojeviZaBrisanje.indexOf(broj.BrojId()) == -1)
                self.BrojeviZaBrisanje.push(broj.BrojId());
        };

};